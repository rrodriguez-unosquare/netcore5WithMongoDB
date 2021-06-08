using Application.Interfaces.Services;
using Application.Services;
using Domain.Interfaces.Models;
using Domain.Models.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class DependencyInjection
    {

        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            // requires using Microsoft.Extensions.Options
            services.Configure<BookstoreDatabaseSettings>(
                configuration.GetSection(nameof(BookstoreDatabaseSettings)));

            services.AddSingleton<IBookstoreDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<BookstoreDatabaseSettings>>().Value);

            services.AddSingleton<IBookService, BookService>();
        }

    }
}
