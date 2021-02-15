using System;
using System.Collections.Generic;
using System.Linq;
using Groww.Buildings;

namespace Groww
{
    public class Program
    {
		public static void Main()
		{
			var tribe = new Tribe
			{
				Buildings = new Building[0],
				Jobs = new Job[]
				{
					new GathererJob
					{
						Workers = 5,
						MaxWorker = 5,
					},
					new HunterJob
					{
						Workers = 5,
						MaxWorker = 5,
					},
				},
				Resources = new Resource[]
				{
					new Resource
					{
						Name = "Food",
						Amount = 10,
						Max = 20,
					}
				},
				Populations = new Population[]
				{
					new Human
					{
						Count = 10,
						Name = "Human",
					}
				}
			};

			var month = 1;
			while (true)
			{
				var food = tribe.Resources.First(r => r.Name == "Food");
				var humans = tribe.Populations.First(r => r.Name == "Human");
				Console.WriteLine($"Food: {food.Amount}");
				Console.WriteLine($"Humans: {humans.Count}");
				
				var command = Console.ReadLine()!;
				
				tribe.Tick(month);
				month++;
				Console.WriteLine();
			}
        }
    }

	public class Tribe
	{
		public IEnumerable<Building> Buildings { get; set; }
		public IEnumerable<Job> Jobs { get; set; }
		public IEnumerable<Resource> Resources { get; set; }
		public IEnumerable<Population> Populations { get; set; }
		
		public void Tick(int month)
		{
			foreach (var job in Jobs)
			{
				job.Tick(this, month);
			}
			foreach (var building in Buildings)
			{
				building.Tick(this, month);
			}
			foreach (var resource in Resources)
			{
				resource.Tick(month);
			}
			foreach (var population in Populations)
			{
				population.Tick(this, month);
			}
		}
	}

	public class Resource
	{
		public string Name { get; set; }
		public int Amount { get; set; }
		public int Max { get; set; }
		
		public void Tick(int month)
		{ }
	}

	public class Population
	{
		public string Name { get; set; }
		public int Count { get; set; }

		public virtual void Tick(Tribe tribe, int month)
		{ }
	}

	public class Human : Population
	{
		private const int _foodConsumption = 1;
		
		public override void Tick(Tribe tribe, int month)
		{
			var food = tribe.Resources.First(r => r.Name == "Food");

			var neededFood = Count * _foodConsumption;
			if (food.Amount >= neededFood)
				food.Amount -= neededFood;
			else
			{
				var deathCount = neededFood - food.Amount;
				Console.WriteLine($"{deathCount} humans starved to death!");
				food.Amount = 0;
				Count -= deathCount;
			}
		}
	}
	
	public abstract class Job
	{
		protected Job(string name)
		{
			Name = name;
		}
		
		public string Name { get; }
		public int DesiredWorker { get; set; }
		public int MaxWorker { get; set; }
		public int Workers { get; set; }

		public abstract void Tick(Tribe tribe, int month);
	}

	public class HunterJob : Job
	{
		public HunterJob() : base("Hunter")
		{
		}

		public override void Tick(Tribe tribe, int month)
		{
			var food = tribe.Resources.First(r => r.Name == "Food");
			
			var collectedFood = Workers * 2;
			food.Amount += collectedFood;
			var deaths = 0;
			for (var i = 0; i < Workers; i++)
			{
				deaths += Rand.Next(100) == 5 ? 1 : 0;
			}
			
			Console.WriteLine($"The hunters collected {collectedFood} food");
			if (deaths > 0)
				Console.WriteLine($"{deaths} hunters died on the job!");
		}
	}

	public class GathererJob : Job
	{
		public GathererJob() : base("Gatherer")
		{ }

		public override void Tick(Tribe tribe, int month)
		{
			var food = tribe.Resources.First(r => r.Name == "Food");
			
			var collectedFood = Workers;
			food.Amount += collectedFood;
			
			Console.WriteLine($"The gatherers collected {collectedFood} food");
		}
	}
}