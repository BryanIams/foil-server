using Domain.Foil.Server.ApplicationConfiguration;
using Domain.Foil.Server.Processors;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Foil.Server.ApplicationConfiguration
{
	public static class ServicesInjection
	{
		public static void Configure(IServiceCollection services)
		{
			services.AddScoped<CardsProcessor>();
			services.AddScoped<SeedsProcessor>();

			ServicesConfiguration.Configure(services);
		}
	}
}