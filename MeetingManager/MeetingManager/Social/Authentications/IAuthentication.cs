using Microsoft.WindowsAzure.MobileServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeetingManager.Social.Authentications
{
    public interface IAuthentication
    {
        Task<MobileServiceUser> LoginAsync(MobileServiceClient client,
                                           MobileServiceAuthenticationProvider provider,
                                           IDictionary<string, string> parameters = null);
    }
}
