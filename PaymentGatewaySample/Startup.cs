﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using PaymentGatewaySample.Domain.Repositories;
using PaymentGatewaySample.Domain.Services;
using PaymentGatewaySample.Domain.Services.Factories;
using PaymentGatewaySample.Integrations.Cielo.Services;
using PaymentGatewaySample.Integrations.Cielo.Services.Interfaces;
using PaymentGatewaySample.Integrations.ClearSale.Services;
using PaymentGatewaySample.Integrations.ClearSale.Services.Interfaces;
using PaymentGatewaySample.Integrations.Stone.Services;
using PaymentGatewaySample.Integrations.Stone.Services.Interfaces;
using PaymentGatewaySample.Repositories.Context;
using PaymentGatewaySample.Repositories.Implementation;
using PaymentGatewaySample.Services.Factories;
using PaymentGatewaySample.Services.Implementation;
using Swashbuckle.AspNetCore.Swagger;

namespace PaymentGatewaySample
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c => {

                c.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "Payment Gateway Sample",
                        Version = "v1",
                        Description = "A payment Gateway sample. Built using netcore 2.1 and Azure SQL Server database.",
                    });
            });

            services.AddMvc().AddJsonOptions(x =>
            {
                x.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                x.SerializerSettings.Formatting = Formatting.Indented;
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("Database")));

            RegisterDependencies(services);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Explore");
            });
            app.UseHttpsRedirection();
            app.UseMvc();
        }

        private void RegisterDependencies(IServiceCollection services)
        {
            services.AddScoped<ISaleProcessor, SaleProcessor>();
            services.Decorate<ISaleProcessor, AntifraudProcessor>();
            services.AddScoped<ITransactionCreator, TransactionCreator>();
            services.AddScoped<ITransactionFinder, TransactionFinder>();
            services.AddScoped<IMerchantFinder, MerchantFinder>();
            services.AddScoped<IMerchantConfigurationAcquirerFinder, MerchantConfigurationAcquirerFinder>();

            services.AddScoped<ICieloService, CieloService>();
            services.AddScoped<ICieloApiClient, CieloApiClientMock>();
            //services.AddScoped<ICieloApiClient, CieloApiClient>();

            services.AddScoped<IStoneService, StoneService>();
            //services.AddScoped<IStoneApiClient, StoneApiClient>();
            services.AddScoped<IStoneApiClient, StoneApiClientMock>();

            services.AddScoped<IClearSaleService, ClearSaleService>();
            //services.AddScoped<IClearSaleApiClient, ClearSaleApiClient>();
            services.AddScoped<IClearSaleApiClient, ClearSaleApiClientMock>();

            services.AddScoped<IAcquirerServiceFactory, AcquirerServiceFactory>();

            services.AddScoped<IMerchantRepository, MerchantRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
        }
    }
}