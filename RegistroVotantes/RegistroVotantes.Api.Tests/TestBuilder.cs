using RegistroVotantes.Domain.Entities;
using RegistroVotantes.Domain.Ports;
using RegistroVotantes.Infrastructure;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Api.Test
{
    public class IntegrationTestBuilder : IDisposable
    {
        protected HttpClient TestClient;
        private IServiceProvider _serviceProvider;
        private bool Disposed;

        protected void BootstrapTestingSuite()
        {
            Disposed = false;
          
            var appFactory = new WebApplicationFactory<RegistroVotantes.Api.Startup>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        var dbCtxOpts = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<PersistenceContext>));

                        if (dbCtxOpts != null)
                        {
                            services.Remove(dbCtxOpts);
                        }

                        services.AddDbContext<PersistenceContext>(options =>
                        {
                            options.UseInMemoryDatabase("TestDb");
                        });

                       
                    });


                });

                
            TestClient = appFactory.CreateClient();
        }      

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (Disposed)
                return;

            if (disposing)
            {
                TestClient.Dispose();
            }

            Disposed = true;
        }


    }
}
