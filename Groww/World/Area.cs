using System.Collections.Generic;

namespace Groww.World
{
	public class World
	{
		public Area[,] Areas { get; set; }

		public void Generate()
		{
			Areas = new Area[100, 100];
			for (var i = 0; i < Areas.GetLength(0); i++)
			{
				for (var j = 0; j < Areas.GetLength(1); j++)
				{
					Areas[i, j] = Rand.Next(2) switch
							   {
								   0 => new Area
								   {
									   Biome = new Biome
									   {
										   Name = "Plain",
										   SpeedMultiplier = 1,
									   },
									   Resources = new []
									   {
										   new Food
										   {
											   Amount = 500,
											   Max = 1000,
											   Name = "Food",
										   },
									   },
								   },
								   1 => new Area
								   {
									   Biome = new Biome
									   {
										   Name = "Forest",
										   SpeedMultiplier = .5,
									   },
									   Resources = new []
									   {
										   new Food
										   {
											   Amount = 1000,
											   Max = 2000,
											   Name = "Food",
										   },
									   },
								   },
								   _ => throw new System.NotImplementedException(),
							   };
				}
			}
		}
	}

    public class Area
    {
        public IEnumerable<Resource> Resources { get; set; }
        public Biome Biome { get; set; }
     }

	public class Biome
	{
		public string Name { get; set; }
		public double SpeedMultiplier { get; set; }
	}
}
