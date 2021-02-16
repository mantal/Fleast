using System.Linq;

namespace Groww.Buildings
{
    public abstract class Building
	{
		public string Name { get; set; }

		public virtual void OnBuild(Tribe tribe) 
		{ }

		public virtual void Tick(Tribe tribe, int month)
		{ }
		
		public virtual void OnDestroyed(Tribe tribe)
		{ }
	}

	public class FoodStore : Building
	{
		public override void OnBuild(Tribe tribe)
		{
			var food = tribe.Resources.First(r => r.Name == "Food");
			food.Max += 10;
		}
	}
}
