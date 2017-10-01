using System.Collections.ObjectModel;
using Data.Foil.Server.Models.Cards;
using Microsoft.Azure.Documents;
using Newtonsoft.Json;

namespace Data.Foil.Server.Models.Decks
{
	public class Deck
	{
		[JsonProperty(PropertyName = "id")]
		public string Id { get; set; }

		[JsonProperty(PropertyName = "title")]
		public string Title { get; set; }

		[JsonProperty(PropertyName = "description")]
		public string Description { get; set; }

		[JsonProperty(PropertyName = "freePeoplesCards")]
		public Collection<Card> FreePeoplesCards { get; set; }

		[JsonProperty(PropertyName = "oneRing")]
		public OneRing OneRing { get; set; }

		[JsonProperty(PropertyName = "shadowCards")]
		public Collection<Card> ShadowCards { get; set; }

		[JsonProperty(PropertyName = "sites")]
		public Collection<Site> Sites { get; set; }
	}
}