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

		[HttpGet("{cardNumber}")]
		public async Task<Card> Get(int cardNumber)
		{
			return await _cardsProcessor.GetCard(cardNumber);
		}
	}
}