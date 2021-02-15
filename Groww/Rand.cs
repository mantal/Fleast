using System;

namespace Groww
{
	public static class Rand
	{
		private static readonly Random _random = new Random();
		
		public static int Next(int max)
			=> Next(0, max);

		public static int Next(int min, int max)
			=> _random.Next(min, max);
	}
}