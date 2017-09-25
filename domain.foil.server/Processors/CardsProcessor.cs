using Data.Foil.Server.Repositories;
using Domain.Foil.Server.DomainTransferObjects.Cards;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Foil.Server.Processors
{
	public class CardsProcessor
	{
		private readonly Repository<Card> _cardRepository;

		public CardsProcessor(Repository<Card> cardRepository)
		{
			_cardRepository = cardRepository;
		}

		public async Task<Card> GetCard(int cardNumber)
		{
			var card = (await _cardRepository.GetItems(x => x.Number == cardNumber)).SingleOrDefault();

			if (card != null)
			{
				return new Card
				{
					Title = card.Title,
					Number = card.Number,
					Description = card.Description,
					Url = card.Url
				};
			}

			return new Card();
		}
	}
}