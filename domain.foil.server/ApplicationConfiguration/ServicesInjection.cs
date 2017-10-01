using AutoMapper;
using Data.Foil.Server.Connections;
using Data.Foil.Server.Repositories;
using Data.Foil.Server.Seeds;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Foil.Server.ApplicationConfiguration
{
	public class ServicesConfiguration
	{
		public static void Configure(IServiceCollection services)
		{
			services.AddAutoMapper();

			services.AddSingleton<CosmosDbConnection>();
			services.AddScoped(typeof(Repository<>), typeof(Repository<>));
			services.AddScoped<SeedData>();
		}
	}
}