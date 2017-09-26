namespace Domain.Foil.Server.DomainTransferObjects.Cards
{
	public class Card
	{
		public string Description { get; set; }

		public string Id { get; set; }

		public string Kind { get; set; }

		public int Number { get; set; }

		public string Title { get; set; }

		public bool Unique { get; set; }

		public string Url { get; set; }
	}
}