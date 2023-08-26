using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CalendarAPI;

class Program
{
	static void Main(string[] args)
	{
		ServiceAccountCredential credential = ServiceAccount.GenerateCredential();
		CalendarService service = CalendarManager.GenerateService(credential);

		Calendar calendar = CalendarManager.GenerateCalendar(service, Rooms.GetRoomLink(0));
		Events events = CalendarManager.MakeRequest(service, calendar);
		List<Event> allEvents = CalendarManager.GetEventList(events);

		CalendarManager.ListingEvents(allEvents);
		Console.Read();

		var startDate = new DateTime(2023, 08, 28, 09, 00, 0);
		var endDate = new DateTime(2023, 08, 28, 12, 00, 0);

		// string startRCF = startDate.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
		string startRCF = startDate.ToString("yyyy-MM-dd HH:mm:ss.fff");
		Console.WriteLine(startRCF);
		// string endRCF = endDate.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
		string endRCF = endDate.ToString("yyyy-MM-dd HH:mm:ss.fff");
		Console.WriteLine(endRCF);

		bool createEvent = CalendarManager.CreateEvent(
			service,
			calendar,
			"Final Project Group Discussion",
			"Forindo, Salatiga, Jawa Tengah, Indonesia",
			"Final Project Group Discussion, Meeting Room Reservation. How can we integrate this GCalendar API with our exists Database to make Reservation feature on our web",
			new EventDateTime()
			{
				// DateTimeDateTimeOffset = new DateTime(2023, 08, 26, 15, 30, 0),
				// DateTimeRaw = "2023-08-26T14:30:00.000Z",
				DateTimeDateTimeOffset = startDate,
				// DateTimeRaw = startRCF,
				TimeZone = "Asia/Jakarta"
			},
			new EventDateTime()
			{
				// DateTimeDateTimeOffset = new DateTime(2023, 08, 26, 16, 30, 0),
				// DateTimeRaw = "2023-08-26T15:30:00.000Z",
				DateTimeDateTimeOffset = endDate,
				// DateTimeRaw = endRCF,
				TimeZone = "Asia/Jakarta"
			},
			new Event.CreatorData()
			{
				DisplayName = "hamirf",
				Email = "haiqi@gmail.com"
			}
		);

		if (createEvent)
		{
			Console.WriteLine("Event created successfully");
		}
		else
		{
			Console.WriteLine("Failed to create event");
		}
	}
}





