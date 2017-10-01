using AutoMapper;
using Data.Foil.Server.Models.Cards;
using Data.Foil.Server.Models.Decks;
using Data.Foil.Server.Repositories;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using utility.foil.server.ApplicationConfiguration.Options;
using Card = Domain.Foil.Server.DomainTransferObjects.Cards.Card;

namespace Domain.Foil.Server.Processors
{
	public class DecksProcessor
	{
		private readonly CDN _cdn;
		private readonly Repository<Deck> _deckRepository;
		private readonly IMapper _mapper;

		public DecksProcessor(Repository<Deck> deckRepository, IOptions<CDN> cdnOptions, IMapper mapper)
		{
			_deckRepository = deckRepository;
			_mapper = mapper;
			_cdn = cdnOptions.Value;
		}

		public async Task<List<DomainTransferObjects.Decks.Deck>> GetDecks()
		{
			var decks = await _deckRepository.GetItems(x => x.Id != null);

			return decks.Select(x => new DomainTransferObjects.Decks.Deck
			{
				OneRing = _mapper.Map<OneRing, DomainTransferObjects.Cards.OneRing>(x.OneRing),
				Title = x.Title,
				Description = x.Description,
				Sites = x.Sites.Select(y => _mapper.Map<Site, DomainTransferObjects.Cards.Site>(y)).ToList(),
				FreePeoplesCards = new List<Card>(),
				Id = x.Id,
				ShadowCards = new List<Card>()
			}).ToList();
		}
	}
}