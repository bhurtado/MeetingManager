using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MeetingManager.Helpers;
using MeetingManager.Droid.Social.Authentications;
using MeetingManager.Social.Authentications;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;

[assembly: Dependency(typeof(SocialAuthentication))]
namespace MeetingManager.Droid.Social.Authentications
{
    public class SocialAuthentication : IAuthentication
    {
        public async Task<MobileServiceUser> LoginAsync(MobileServiceClient client, 
                                                        MobileServiceAuthenticationProvider provider, 
                                                        IDictionary<string, string> parameters = null)
        {
            try
            {
                var user = await client.LoginAsync(Forms.Context, provider);

                Settings.AuthToken = user?.MobileServiceAuthenticationToken ?? string.Empty;
                Settings.UserId = user?.UserId;

                return user;
            }
            catch (Exception)
            {
                // TODO: Log error
                throw;
            }
        }
    }
}