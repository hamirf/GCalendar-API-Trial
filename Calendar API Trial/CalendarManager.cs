using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;

namespace CalendarAPI;

public static class CalendarManager
{
	public static CalendarService GenerateService(UserCredential credential)
	{
		var service = new CalendarService(new BaseClientService.Initializer()
		{
			HttpClientInitializer = credential,
			ApplicationName = "CalendarApp"
		});

		return service;
	}

	public static Calendar GenerateCalendar(CalendarService service, string calId) // calendar's Id 
	{
		var calendar = service.Calendars.Get(calId).Execute();
		return calendar;
	}

	public static Events MakeRequest(CalendarService service, Calendar calendar)
	{
		// Define parameters of request.
		EventsResource.ListRequest listRequest = service.Events.List(calendar.Id);
		listRequest.TimeMin = DateTime.Now;
		listRequest.ShowDeleted = false;
		listRequest.SingleEvents = true;
		listRequest.MaxResults = 10;
		listRequest.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

		// List events.
		Events events = listRequest.Execute();

		return events;
	}

	public static List<Event> GetEventList(Events events)
	{
		return events.Items.ToList();
	}

	public static bool ListingEvents(List<Event> events)
	{
		if (events != null && events.Count > 0)
		{
			foreach (var singleEvent in events)
			{
				Console.WriteLine("------------------------------");
				Console.WriteLine($"Event Id 			: {singleEvent.Id}");
				Console.WriteLine($"Event Summary 		: {singleEvent.Summary}");
				Console.WriteLine($"Event Location 		: {singleEvent.Location}");
				Console.WriteLine($"Event Description 	: {singleEvent.Description}");
				Console.WriteLine($"Event Start/TimeZone: {singleEvent.Start.DateTime.ToString()}, {singleEvent.Start.TimeZone}");
				Console.WriteLine($"Event End/Timezone	: {singleEvent.End.DateTime.ToString()}, {singleEvent.End.TimeZone}");
				Console.Write($"Event Attendees		: ");
				if (singleEvent.Attendees != null)
				{
					foreach (var attendee in singleEvent.Attendees)
					{
						Console.Write($"{attendee.Email}, ");
					}
				}
				Console.WriteLine();
			}
		}
		else
		{
			Console.WriteLine("No upcoming events found.");
		}
		return true;
	}

	public static bool CreateEvent(
		CalendarService service,
		Calendar calendar,
		string summary,
		string location,
		string description,
		EventDateTime start,
		EventDateTime end,
		IList<EventAttendee> attendees
	)
	{
		Event eventInsert = new Event()
		{
			Summary = summary,
			Location = location,
			Description = description,
			Start = start,
			End = end,
			Attendees = attendees
		};

		var InsertRequest = service.Events.Insert(eventInsert, calendar.Id);

		try
		{
			InsertRequest.Execute();
			return true;
		}
		catch (Exception)
		{
			try
			{
				service.Events.Update(eventInsert, calendar.Id, eventInsert.Id).Execute();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
	}
}