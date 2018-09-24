using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace TriviaServer
{
	public static class IWebHostExtensions
	{
		public static IWebHost MigrateDatabase(this IWebHost webHost)
		{
			// Manually run any outstanding migrations if configured to do so
			var envAutoMigrate = Environment.GetEnvironmentVariable("AUTO_MIGRATE");
			if (envAutoMigrate != null && envAutoMigrate == "true")
			{
				Console.WriteLine("*** AUTO MIGRATE ***");

				var serviceScopeFactory = (IServiceScopeFactory)webHost.Services.GetService(typeof(IServiceScopeFactory));

				using (var scope = serviceScopeFactory.CreateScope())
				{
					var services = scope.ServiceProvider;
					var dbContext = services.GetRequiredService<ApplicationContext>();

					dbContext.Database.Migrate();
				}
			}

			return webHost;
		}
	}
}
