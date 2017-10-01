using Domain.Foil.Server.DomainTransferObjects.Decks;
using Domain.Foil.Server.Processors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.foil.server.Controllers
{
	[Produces("application/json")]
	[Route("api/Decks")]
	public class DecksController : Controller
	{
		private readonly DecksProcessor _decksProcessor;

		public DecksController(DecksProcessor decksProcessor)
		{
			_decksProcessor = decksProcessor;
		}

		[HttpGet]
		public async Task<List<Deck>> Get()
		{
			return await _decksProcessor.GetDecks();
		}
	}
}