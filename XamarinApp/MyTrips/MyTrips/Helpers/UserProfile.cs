﻿using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using MyTrips.Utils;

namespace MyTrips.Helpers
{
    public class UserProfileHelper
    {
        //returns info for the authenticated user
        public static async Task<UserProfile> GetUserProfileAsync(IMobileServiceClient client)
        {
            var userprof =
            await client.InvokeApiAsync<UserProfile>(
                "UserInfo",
                System.Net.Http.HttpMethod.Get,
                null);

            Settings.Current.UserFirstName = userprof?.FirstName ?? string.Empty;
            Settings.Current.UserLastName = userprof?.LastName ?? string.Empty;
            Settings.Current.UserProfileUrl = userprof?.ProfilePictureUri ?? string.Empty;

            return userprof;
        }
    }
}

namespace MyTrips
{
    public class UserProfile
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePictureUri { get; set; }
    }
}
