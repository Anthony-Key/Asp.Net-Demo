﻿using Microsoft.EntityFrameworkCore;
using MVC_AK.Models;

namespace MVC_AK
{
    public class Startup
    {
        private IConfigurationRoot Configuration { get; set; }

        public Startup(IConfigurationRoot configuration)
        {
            Configuration = configuration;
        }

        public void ConfigurationServices(IServiceCollection services, string environment)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddDbContext<MovieDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("dbConnection")));
        }
    }
}
