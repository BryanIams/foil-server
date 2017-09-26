using Newtonsoft.Json;

namespace Data.Foil.Server.Models.Cards
{
	public class Site : Card
	{
		[JsonProperty(PropertyName = "shadow")]
		public int Shadow { get; set; }

		[JsonProperty(PropertyName = "site_number")]
		public int SiteNumber { get; set; }
	}
}