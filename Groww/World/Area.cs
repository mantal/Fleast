using System.Collections.Generic;
using System.Linq;

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

	public abstract class Action
	{
		public string Name { get; protected init; }

		public abstract bool IsAvailable(Area area);
		public abstract void Do(Area area, Tribe tribe);
	}

	public class GatherFood : Action
	{
		public GatherFood()
		{
			Name = "Gather food";
		}

		public override bool IsAvailable(Area area)
		{
			var resource = area.Resources.FirstOrDefault(r => r.Name == Resource.Food);

			return resource != null && resource.Amount > 0;
		}

		public override void Do(Area area, Tribe tribe)
		{
			var areaResource = area.Resources.First(r => r.Name == Resource.Food);
			var tribeResource = tribe.Resources.FirstOrDefault(r => r.Name == Resource.Food);

			var amount = 5;
			if (tribeResource == null)
			{
				tribe.Resources = tribe.Resources.Append(new Resource
				{
					Amount = amount,
					Max = 5,
					Name = Resource.Food,
				});
				return;
			}

			tribeResource.Amount += amount;//todo
		}
	}

	public class GatherWood : Action
	{
		public GatherWood()
		{
			Name = "Gather wood";
		}

		public override bool IsAvailable(Area area)
		{
			var resource = area.Resources.FirstOrDefault(r => r.Name == Resource.Wood);

			return resource != null && resource.Amount > 0;
		}

		public override void Do(Area area, Tribe tribe)
		{
			var areaResource = area.Resources.First(r => r.Name == Resource.Wood);
			var tribeResource = tribe.Resources.FirstOrDefault(r => r.Name == Resource.Wood);

			var amount = 5;
			if (tribeResource == null)
			{
				tribe.Resources = tribe.Resources.Append(new Resource
				{
					Amount = amount,
					Max = 5,
					Name = Resource.Wood,
				});
				return;
			}

			tribeResource.Amount += amount; //todo
		}
	}
}
