using System.Collections.Generic;
using Domain.Foil.Server.DomainTransferObjects.Cards;

namespace Domain.Foil.Server.DomainTransferObjects.Decks
{
	public class Deck
	{
		public string Description { get; set; }

		public List<Card> FreePeoplesCards { get; set; }

		public string Id { get; set; }

		public OneRing OneRing { get; set; }

		public List<Card> ShadowCards { get; set; }

		public List<Site> Sites { get; set; }

		public string Title { get; set; }
	}
}