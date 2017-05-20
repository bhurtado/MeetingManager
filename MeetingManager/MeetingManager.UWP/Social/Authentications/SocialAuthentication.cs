using MeetingManager.Helpers;
using MeetingManager.Social.Authentications;
using MeetingManager.UWP.Social.Authentications;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(SocialAuthentication))]
namespace MeetingManager.UWP.Social.Authentications
{
    public class SocialAuthentication : IAuthentication
    {
        public async Task<MobileServiceUser> LoginAsync(MobileServiceClient client,
                                                        MobileServiceAuthenticationProvider provider,
                                                        IDictionary<string, string> parameters = null)
        {
            try
            {
                var user = await client.LoginAsync(provider);
                
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
