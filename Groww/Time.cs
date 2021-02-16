namespace Groww
{
	public record Time
	{
		private int _tick = 1;

		public void Tick() => _tick++;

		public static implicit operator int(Time t)
			=> t._tick;
	}
}