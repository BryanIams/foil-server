using AutoMapper;
using Domain.Foil.Server.DomainTransferObjects.Cards;

namespace Domain.Foil.Server.ApplicationConfiguration
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Card, Data.Foil.Server.Models.Cards.Card>();
			CreateMap<Data.Foil.Server.Models.Cards.Card, Card>();

			CreateMap<OneRing, Data.Foil.Server.Models.Cards.OneRing>()
				.IncludeBase<Card, Data.Foil.Server.Models.Cards.Card>();
			CreateMap<Data.Foil.Server.Models.Cards.OneRing, OneRing>()
				.IncludeBase<Data.Foil.Server.Models.Cards.Card, Card>();

			CreateMap<Site, Data.Foil.Server.Models.Cards.Site>()
				.IncludeBase<Card, Data.Foil.Server.Models.Cards.Card>();
			CreateMap<Data.Foil.Server.Models.Cards.Site, Site>()
				.IncludeBase<Data.Foil.Server.Models.Cards.Card, Card>();
		}
	}
}