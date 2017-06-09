using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace NFLTeamsApp.Helpers
{
    public static class Settings
    {
        private static ISettings AppSettings => CrossSettings.Current;

        const string UserIdKey = "userid";
        static readonly string UserIdDefault = string.Empty;
        public static string UserId
        {
            get { return AppSettings.GetValueOrDefault<string>(UserIdKey, UserIdDefault); }
            set { AppSettings.AddOrUpdateValue<string>(UserIdKey, value); }
        }

        const string AuthTokenKey = "authtoken";
        static readonly string AuthTokenDefault = string.Empty;
        public static string AuthToken
        {
            get { return AppSettings.GetValueOrDefault<string>(AuthTokenKey, AuthTokenDefault); }
            set { AppSettings.AddOrUpdateValue<string>(AuthTokenKey, value); }
        }

        const string UserTokenKey = "id_token";
        static readonly string UserTokenDefault = string.Empty;
        public static string UserToken
        {
            get { return AppSettings.GetValueOrDefault<string>(UserTokenKey, UserTokenDefault); }
            set { AppSettings.AddOrUpdateValue<string>(UserTokenKey, value); }
        }

        const string UserIdentificationKey = "user_identification";
        static readonly string UserIdentificationDefault = string.Empty;
        public static string UserIdentification
        {
            get { return AppSettings.GetValueOrDefault<string>(UserIdentificationKey, UserIdentificationDefault); }
            set { AppSettings.AddOrUpdateValue<string>(UserIdentificationKey, value); }
        }

        const string UserAvatarKey = "user_avatar";
        static readonly string UserAvatarDefault = string.Empty;
        public static string UserAvatar
        {
            get { return AppSettings.GetValueOrDefault<string>(UserAvatarKey, UserAvatarDefault); }
            set { AppSettings.AddOrUpdateValue<string>(UserAvatarKey, value); }
        }

        private static bool IsLoggedInDefault;
        public static bool IsLoggedIn
        {
            get { return !string.IsNullOrWhiteSpace(UserId); }
            set { IsLoggedInDefault = value; }
        }
    }
}