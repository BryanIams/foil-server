using Newtonsoft.Json;

namespace Data.Foil.Server.Models.Cards
{
	public class OneRing : Card
	{
		[JsonProperty(PropertyName = "health_modifier")]
		public int HealthModifier { get; set; }

		[JsonProperty(PropertyName = "strength_modifier")]
		public int StrengthModifier { get; set; }
	}
}