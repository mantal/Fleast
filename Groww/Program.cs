using System.Collections.Generic;
using Groww.Buildings;
using Groww.World;

namespace Groww
{
	public class Game
	{
		public Time Time { get; private set; }
		public Tribe Tribe { get; private set; }
		public World.World World { get; private set; }

		public Game()
		{
			Time = new Time();
            Tribe = new Tribe
            {
                Buildings = new List<Building>(),
                Resources = new Resource[]
                {
                    new Resource
                    {
                        Name = Resource.Food,
                        Amount = 10,
                        Max = 20,
                    },
					new Resource
					{
						Name = Resource.Wood,
						Amount = 0,
						Max = 10,
					},
                },
                Humans = new List<Human>
                {
                    new()
                    {
                        Age = new Time(),
                        Health = 100,
                        Name = "Lynn",
                    },
                    new()
                    {
                        Age = new Time(),
                        Health = 100,
                        Name = "Alex",
                    },
                },
				Actions = new List<Action>
				{
					new GatherFood(),
					new GatherWood(),
				}
            };

            World = new World.World();
		}

		public void Init()
		{
			World.Generate();
			Tribe.PosX = 25;
			Tribe.PosY = 25;
		}

		public void Tick()
		{
			Tribe.Tick(Time);
		}
	}

	public class Tribe : Entity
	{
		public IEnumerable<Building> Buildings { get; set; } = new List<Building>();
		public IEnumerable<Resource> Resources { get; set; } = new List<Resource>();
		public IEnumerable<Human> Humans { get; set; } = new List<Human>();
		public IEnumerable<Action> Actions { get; set; } = new List<Action>();

		public int PosX { get; set; }
		public int PosY { get; set; }

		public override void Tick(Time time)
		{
			foreach (var building in Buildings)
			{
				building.Tick(this, time);
			}
			foreach (var resource in Resources)
			{
				resource.Tick(time);
			}
			foreach (var population in Humans)
			{
				population.Tick(this, time);
			}
		}
	}

	public class Entity
	{
		public string Name { get; set; }

		public virtual void Tick(Time time)
		{ }
	}

	public class Population : Entity
	{
		public int Health { get; set; }
		public Time Age { get; set; }
		public string Specie { get; set; }
	}

	public class Human : Population
	{
		private const int _foodConsumption = 1;

		public void Tick(Tribe tribe, Time time)
		{
			Tick(time);
		}
	}
}