using System;
using System.Threading.Tasks;
using TrokaTroka.Api.Dtos.InputModels;
using TrokaTroka.Api.Dtos.ViewModels;
using TrokaTroka.Api.Infra.Context;
using TrokaTroka.Api.Interfaces;
using TrokaTroka.Api.Interfaces.Repositories;
using TrokaTroka.Api.Interfaces.Services;
using TrokaTroka.Api.Models;
using TrokaTroka.Api.Notifications;

namespace TrokaTroka.Api.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly TrokatrokaDbContext _context;
        private readonly IUserRepository _userRepository;
        private readonly IBlobStorageService _blobStorageService;
        public UserService(IUserRepository userRepository,
            IAuthenticatedUser user,
            IBlobStorageService blobStorageService,
            TrokatrokaDbContext context,
            INotifier notifier) : base(user, notifier)
        {
            _userRepository = userRepository;
            _blobStorageService = blobStorageService;
            _context = context;
        }

        public async Task<UserViewModel> UpdateUser(UpdateUserInputModel inputModel)
        {
            var user = await _userRepository.GetUserById(inputModel.Id);

            if (await _userRepository.GetUserByEmail(inputModel.Email) != null && user.Email != inputModel.Email)
            {
                Notify("Email já cadastrado");
                return null;
            }

            if (inputModel.Avatar is not null)
            {
                var avatar = _blobStorageService.UploadFileToBlobWithName(inputModel.Avatar, user.Id, "avatars", user.Id.ToString());
                user.UpdateAvatar(avatar.Name, $"{avatar.Uri}/{avatar.Name}");
            }
            
            user.UpdateUser(inputModel.Name, inputModel.Document, inputModel.Email);

            await _userRepository.Update(user);

            return new UserViewModel()
            {
                Id = user.Id,
                Name = user.Name,
                Document = user.Document,
                Email = user.Email,
                AvatarPath = user.AvatarPath
            };
        }
    }
}