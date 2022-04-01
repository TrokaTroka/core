using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TrokaTroka.Api.Dtos.InputModels;
using TrokaTroka.Api.Dtos.ViewModels;
using TrokaTroka.Api.Extensions;
using TrokaTroka.Api.Infra.Context;
using TrokaTroka.Api.Interfaces;
using TrokaTroka.Api.Interfaces.Repositories;
using TrokaTroka.Api.Interfaces.Services;
using TrokaTroka.Api.Models;
using TrokaTroka.Api.Notifications;

namespace TrokaTroka.Api.Services
{
    public class AuthService : BaseService, IAuthService
    {
        private readonly TrokatrokaDbContext _context;
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository,
            IAuthenticatedUser user,
            TrokatrokaDbContext context,
            INotifier notifier) : base(user, notifier)
        {
            _userRepository = userRepository;
            _context = context;
        }
        
        public async Task<TokenViewModel> CreateUser(CreateUserInputModel userInput)
        {
            if (await _userRepository.GetUserByEmail(userInput.Email) != null)
            {
                Notify("Email já cadastrado");
                return null;
            }

            var user = new User(userInput.Email, ComputeSha256Hash(userInput.Password), userInput.Name);
            user.UnmaskDocument(userInput.Document);

            await _userRepository.Create(user);

            var token = GerarJwtToken(user.Email);

            var userVM = new UserViewModel()
            {
                Id = user.Id,
                Name = user.Name,
                Document = user.Document,   
                Email = user.Email,
                AvatarPath = user.AvatarPath
            };

            var refreshToken = GerarRefreshToken(user.Email).Result;
                     
            return new TokenViewModel()
            {
                User = userVM,
                Token = token,
                RefreshToken = refreshToken.Token,
                Expiration = DateTime.UtcNow.AddHours(AppSettings.Instance.RefreshTokenExpiration)
            };
        }


        public async Task<TokenViewModel> AuthUser(LoginInputModel loginInput)
        {
            var user = await _userRepository.UserAuth(loginInput.Email, ComputeSha256Hash(loginInput.Password));

            if (user == null)
            {
                Notify("Email ou senha incorretos");
                return null;
            }

            var token = GerarJwtToken(user.Email);

            var userVM = new UserViewModel()
            {
                Id = user.Id,
                Name = user.Name,
                Document = user.Document,
                Email = user.Email,
                AvatarPath = user.AvatarPath
            };

            var refreshToken = GerarRefreshToken(loginInput.Email).Result;

            return new TokenViewModel()
            {
                User = userVM,
                Token = token,
                RefreshToken = refreshToken.Token,
                Expiration = DateTime.UtcNow.AddHours(AppSettings.Instance.RefreshTokenExpiration)
            };
        }

        public string GerarJwtToken(string email)
        {
            var key = AppSettings.Instance.SecretKey;
            var issuer = AppSettings.Instance.Issuer;
            var audience = AppSettings.Instance.Audience;

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Name, email)
                    }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = credentials,
                Issuer = issuer,
                Audience = audience
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var stringToken = tokenHandler.CreateToken(token);

            return tokenHandler.WriteToken(stringToken);
        }

        private static string ComputeSha256Hash(string password)
        {
            using SHA256 sha256Hash = SHA256.Create();
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

            var builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }

            return builder.ToString();
        }

        private async Task<RefreshToken> GerarRefreshToken(string email)
        {
            var refreshToken = new RefreshToken
            {
                Username = email,
                ExpirationDate = DateTime.UtcNow.AddHours(AppSettings.Instance.RefreshTokenExpiration)
            };

            _context.RefreshTokens.RemoveRange(_context.RefreshTokens.Where(r => r.Username == email));
            await _context.RefreshTokens.AddAsync(refreshToken);

            await _context.SaveChangesAsync();

            return refreshToken;
        }

        public async Task<RefreshToken> ObterRefreshToken(Guid refreshToken)
        {
            var token = await _context.RefreshTokens.AsNoTracking()
                .FirstOrDefaultAsync(r => r.Token == refreshToken);

            return token != null && token.ExpirationDate.ToLocalTime() > DateTime.Now
                ? token
                : null;
        }
    }
}