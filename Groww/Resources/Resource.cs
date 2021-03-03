namespace Groww
{
	public class Resource
	{
		public string Name { get; set; }
		public int Amount { get; set; }
		public int Max { get; set; }
		
		public void Tick(int month)
		{ }

		public static string Food { get; } = "Food";//tmp
		public static string Wood { get; } = "Wood";//tmp
	}

	public class Food : Resource
	{ }
}