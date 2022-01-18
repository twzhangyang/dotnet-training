using System;
using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebApi.Infrastructure;
using WebApi.Tests.TestSeeds;

namespace WebApi.Tests.Artist;

public class MusicWebApplicationFactory<TStartup>
    : WebApplicationFactory<TStartup> where TStartup : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var descriptor = services.Single(d => d.ServiceType == typeof(DbContextOptions<MusicDbContext>));
            services.Remove(descriptor);
            services.AddDbContext<MusicDbContext>(options => { options.UseInMemoryDatabase("InMemoryDbForTesting"); });

            var sp = services.BuildServiceProvider();

            using (var scope = sp.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MusicDbContext>();

                TestSeedsInitializer.Initialize(db);
                db.Database.EnsureCreated();
            }
        });

        // Inject mock services
        builder.ConfigureTestServices(builder => { });
    }
}
