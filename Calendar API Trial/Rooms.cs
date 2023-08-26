namespace CalendarAPI;

// These are Calendar's Ids from personal account

public static class Rooms
{
	private static List<string> RoomLink = new List<string>
	{
		@"244818f2ae9e65049c4ed3bd40744291d1aa439fa6377a0403b6f406831adc6d@group.calendar.google.com", // Meeting Room 1
		@"7d10fb4b0a6688238408fcd7e531bea96eaa728dfe590a7a97e1017afba5fa52@group.calendar.google.com", // Meeting Room 2
		@"a5062b4a6b928018e6bce4529c0f4792952e5d385b32cf1ff429513052cb5bad@group.calendar.google.com"  // Meeting Room 3
	};
	
	public static List<string> GetAllRoom()
	{
		return RoomLink;
	}
	
	public static string GetRoomLink(int index)
	{
		return RoomLink[index];
	}
}