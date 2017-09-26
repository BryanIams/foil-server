using Data.Foil.Server.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Data.Foil.Server.Models.Cards
{
	public class Card
	{
		[JsonProperty(PropertyName = "description")]
		public string Description { get; set; }

		[JsonProperty(PropertyName = "id")]
		public string Id { get; set; }

		[JsonProperty(PropertyName = "number")]
		public int Number { get; set; }

		[JsonProperty(PropertyName = "title")]
		public string Title { get; set; }

		[JsonProperty(PropertyName = "url")]
		public string Url { get; set; }

		[JsonProperty(PropertyName = "unique")]
		public bool Unique { get; set; }

		[JsonConverter(typeof(StringEnumConverter)), JsonProperty(PropertyName = "kind")]
		public CardKind Kind { get; set; }
	}
}