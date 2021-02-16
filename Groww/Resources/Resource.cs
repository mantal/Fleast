namespace Groww
{
	public class Resource
	{
		public string Name { get; set; }
		public int Amount { get; set; }
		public int Max { get; set; }
		
		public void Tick(int month)
		{ }
	}

	public class Food : Resource
	{ }
}