using Data.Foil.Server.Seeds;
using System.Threading.Tasks;

namespace Domain.Foil.Server.Processors
{
	public class SeedsProcessor
	{
		private readonly SeedData _seedData;

		public SeedsProcessor(SeedData seedData)
		{
			_seedData = seedData;
		}

		public async Task SeedData()
		{
			await _seedData.Seed();
		}
	}
}