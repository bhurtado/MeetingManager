using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingManager
{
    public static class Configuration
    {
        public static readonly string HubPath = "MeetingManagerPushHub";
        public static readonly string ConnectionString = "Endpoint=sb://meetingmanagerpushhubnamespace.servicebus.windows.net/;SharedAccessKeyName=DefaultListenSharedAccessSignature;SharedAccessKey=MZ7qf4RlkMuRl5QulMkHeGEsj7950uheHuDTWwy7yog=";
    }
}
