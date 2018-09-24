using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TriviaServer.Controllers.API;
using TriviaServer.DAO.Interfaces;
using TriviaServer.DAO.Repositories;

namespace TriviaServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                    });
            });

            // services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvc();

            //services.AddDbContext<ApplicationContext>(options =>
            //options.UseSqlServer(Configuration.GetConnectionString("ConnectionString")));

	        services.AddEntityFrameworkNpgsql().AddDbContext<ApplicationContext>(options =>
	        {
		        var connUrl = Environment.GetEnvironmentVariable("DATABASE_URL");

				// Parse connection URL to connection string for Npgsql
		        connUrl = connUrl.Replace("postgres://", string.Empty);

		        var pgUserPass = connUrl.Split("@")[0];
		        var pgHostPortDb = connUrl.Split("@")[1];
		        var pgHostPort = pgHostPortDb.Split("/")[0];

		        var pgDb = pgHostPortDb.Split("/")[1];
		        var pgUser = pgUserPass.Split(":")[0];
		        var pgPass = pgUserPass.Split(":")[1];
		        var pgHost = pgHostPort.Split(":")[0];
		        var pgPort = pgHostPort.Split(":")[1];

		        options.UseNpgsql(Configuration.GetConnectionString($"Server={pgHost};Port={pgPort};User Id={pgUser};Password={pgPass};Database={pgDb}"));

		        //options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
	        });

            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IGameRepository, GameRepository>();
            services.AddTransient<IPlayerRepository, PlayerRepository>();
            services.AddTransient<IQuestionRepository, QuestionRepository>();
            services.AddTransient<ICategoryGame, CategoryGameRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
           // app.UseMvc(ConfigureRoutes);

            app.UseHttpsRedirection();
            app.UseCors("AllowAll");
            app.UseMvc();
           
        }
    }
}
