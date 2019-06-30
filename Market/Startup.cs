using Market.Component.Item;
using Market.Component.Item.Interface;
using Market.Config;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Market
{
    public class Startup
    {
        public IConfiguration configuration { get; }

        public Startup (IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<MarketDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("DevLocalDbMarket"));
            });

            services.AddTransient<IItemRepository, ItemRepository>();


            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Market Api",
                    Version = "V1",
                    Contact = new OpenApiContact { Email = "ahmednasser1993@gmail.com", Name = "Ahmed Nasser" },
                    Description = "Learning Asp.Net Core"
                });
            });

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
           {
               c.SwaggerEndpoint("/swagger/v1/swagger.json", "Market V1");
               c.RoutePrefix = string.Empty;
           });

            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
