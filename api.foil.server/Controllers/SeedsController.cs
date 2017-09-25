using Domain.Foil.Server.Processors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace api.foil.server.Controllers
{
	[Produces("application/json")]
	[Route("api/seeds")]
	public class SeedsController : Controller
	{
		private readonly SeedsProcessor _seedsProcessor;

		public SeedsController(SeedsProcessor seedsProcessor)
		{
			_seedsProcessor = seedsProcessor;
		}

		[HttpPost]
		public async Task Post([FromBody]string seedCode)
		{
				await _seedsProcessor.SeedData();
		}
	}
}