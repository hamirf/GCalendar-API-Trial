using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;

namespace CalendarAPI;

public static class ServiceAccount
{
	public static ServiceAccountCredential GenerateCredential()
	{
		string jsonFile = "fmlx-meeting-room-app-5df96b10357a.json"; // change this value to your own personal service account json
		string[] Scopes = { CalendarService.Scope.Calendar };
		ServiceAccountCredential credential;

		using (var stream =
			new FileStream(jsonFile, FileMode.Open, FileAccess.Read))
		{
			var confg = Google.Apis.Json.NewtonsoftJsonSerializer.Instance.Deserialize<JsonCredentialParameters>(stream);
			credential = new ServiceAccountCredential(
			   new ServiceAccountCredential.Initializer(confg.ClientEmail)
			   {
				   Scopes = Scopes
			   }.FromPrivateKey(confg.PrivateKey));
		}
		
		return credential;
	}
}