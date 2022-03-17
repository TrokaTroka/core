namespace TrokaTroka.Api.Extensions
{
    public class AppSettings
    {
        public static AppSettings Instance { get; private set; }

        public string SecretKey { get; set; }

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public int RefreshTokenExpiration { get; set; }

        public static void Initialize(AppSettings appSettings)
        {
            Instance = appSettings;
        }
    }
}