using Newtonsoft.Json;

namespace MeetingManager.Social.Facebook.Models
{
    public class User
    {
        [JsonProperty("userId")]
        public string UserId { get; set; }
    }
}
