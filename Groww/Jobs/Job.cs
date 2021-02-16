namespace Groww
{
	public abstract class Job
	{
		public string Name { get; set; }

		public abstract void Tick(Tribe tribe, int month);
	}
}