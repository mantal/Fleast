using System;
using System.Collections.Generic;
using System.Linq;
using Groww.Buildings;

namespace Groww
{
	public class Game
	{
		public Time Time { get; private set; }
		public Tribe Tribe { get; private set; }

		public void Init()
		{
			Time = new Time();
			Tribe = new Tribe
			{
				Buildings = new List<Building>(),
				Resources = new Resource[]
				{
					new Resource
					{
						Name = "Food",
						Amount = 10,
						Max = 20,
					}
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
				}
			};
		}

		public void Tick()
		{

		}
	}

	public class Tribe : Entity
	{
		public IEnumerable<Building> Buildings { get; set; }
		public IEnumerable<Resource> Resources { get; set; }
		public IEnumerable<Human> Humans { get; set; }
		
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