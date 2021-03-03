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
									   Biome = Biome.Plains,
									   Resources = Biome.Plains.Resources,
								   },
								   1 => new Area
								   {
									   Biome = Biome.Forest,
									   Resources = Biome.Forest.Resources,
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
}
