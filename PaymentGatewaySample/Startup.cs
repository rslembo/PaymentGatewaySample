﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PaymentGatewaySample.Domain.Repositories;
using PaymentGatewaySample.Domain.Services;
using PaymentGatewaySample.Domain.Services.Factories;
using PaymentGatewaySample.Integrations.Cielo.Services;
using PaymentGatewaySample.Integrations.Stone.Services;
using PaymentGatewaySample.Repositories.Context;
using PaymentGatewaySample.Repositories.Implementation;
using PaymentGatewaySample.Services.Factories;
using PaymentGatewaySample.Services.Implementation;

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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<ApplicationDbContext>(options => 
                options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("Database")));


            services.AddScoped<ISaleService, SaleService>();
            services.AddScoped<ITransactionFinder, TransactionFinder>();
            services.AddScoped<IMerchantFinder, MerchantFinder>();
            services.AddScoped<IMerchantConfigurationAcquirerFinder, MerchantConfigurationAcquirerFinder>();
            services.AddScoped<ICieloService, CieloService>();
            services.AddScoped<IStoneService, StoneService>();

            services.AddScoped<IAcquirerServiceFactory, AcquirerServiceFactory>();

            services.AddScoped<IMerchantRepository, MerchantRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            //services.AddScoped<IMerchantRepository, MerchantRepositoryMock>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}