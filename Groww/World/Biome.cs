namespace Groww.World
{
	public record Biome(string Name,
						double SpeedMultiplier,
						Resource[] Resources)
	{

		public static Biome Plains { get; } = new("Plains",
												  1,
												  new Resource[]
												  {
													  new Food
													  {
														  Amount = 1000,
														  Max = 2000,
														  Name = "Food",
													  },
												  });

		public static Biome Forest { get; } = new("Forest",
												  .8,
												  new Resource[]
												  {
													  new Food
													  {
														  Amount = 1000,
														  Max = 2000,
														  Name = "Food",
													  },
												  });
	}
}