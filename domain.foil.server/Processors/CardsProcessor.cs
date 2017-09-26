using Data.Foil.Server.Repositories;
using Domain.Foil.Server.DomainTransferObjects.Cards;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using utility.foil.server.ApplicationConfiguration.Options;

namespace Domain.Foil.Server.Processors
{
	public class CardsProcessor
	{
		private readonly Repository<Data.Foil.Server.Models.Cards.Card> _cardRepository;
		private readonly CDN _cdn;


		public CardsProcessor(Repository<Data.Foil.Server.Models.Cards.Card> cardRepository, IOptions<CDN> cdnOptions)
		{
			_cardRepository = cardRepository;
			_cdn = cdnOptions.Value;
		}

		public async Task<Card> GetCardById(string id)
		{
			var card = (await _cardRepository.Get(id));


			if (card != null)
			{
				return new Card
				{
					Title = card.Title,
					Number = card.Number,
					Description = card.Description,
					Url = $"{_cdn.Url}/{card.Url}"
				};
			}

			return new Card();
		}

		public async Task<Card> GetCardByNumber(int cardNumber)
		{
			var card = (await _cardRepository.GetItems(x => x.Number == cardNumber)).SingleOrDefault();

			if (card != null)
			{
				return new Card
				{
					Title = card.Title,
					Number = card.Number,
					Description = card.Description,
					Url = $"{_cdn.Url}/{card.Url}"
				};
			}

			return new Card();
		}
	}
}