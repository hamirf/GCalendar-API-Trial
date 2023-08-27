using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Calendar.v3;
using Google.Apis.Util.Store;

namespace Calendar_API_Trial
{
    public static class GoogleOAuth
    {
        public static UserCredential GenerateCredential()
        {
            UserCredential credential;

            string[] scopes = { CalendarService.Scope.Calendar };

            using (var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets,
                    scopes, "hamirf", CancellationToken.None, new FileDataStore("./credentials/calendar-dotnet-quickstart.json", true)).Result;
            }
            return credential;
        }
    }
}