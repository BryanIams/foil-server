using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Foil.Server.DomainTransferObjects.Cards;
using Domain.Foil.Server.Processors;
using Microsoft.AspNetCore.Mvc;

namespace Api.Foil.Server.Controllers
{
	[Produces("application/json")]
	[Route("api/cards")]
	public class CardsController : Controller
	{
		private readonly CardsProcessor _cardsProcessor;

		public CardsController(CardsProcessor cardsProcessor)
		{
			_cardsProcessor = cardsProcessor;
		}

		[HttpGet]
		public async Task<IEnumerable<Card>> Get()
		{
			return await _cardsProcessor.GetCards();
		}

		[HttpGet("{id}")]
		public async Task<Card> Get(string id)
		{
			return await _cardsProcessor.GetCardById(id);
		}

		[HttpGet("number/{cardNumber}")]
		public async Task<Card> Get(int cardNumber)
		{
			return await _cardsProcessor.GetCardByNumber(cardNumber);
		}
	}
}