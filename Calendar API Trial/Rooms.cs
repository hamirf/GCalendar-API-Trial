namespace CalendarAPI;

// These are Calendar's Ids from personal account

public static class Rooms
{
	private static List<string> RoomLink = new List<string>
	{
		@"8b0bad6ede2945ad0821d6d1520817dfbb5ef0b5d8f7ba8b345da923d40b8125@group.calendar.google.com", // Meeting Room 1
		@"356e9d1d8ed492ed2e31b2fc8bb8e5a85c957c194f4c7af63ef98dba14e8e572@group.calendar.google.com", // Meeting Room 2
		@"d98697639dff0dea529adce8a6bc75324277bcfbf9641cb4ab4b4158650a90f2@group.calendar.google.com"  // Meeting Room 3
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