using CustomerInquiry.DataAccess;
using CustomerInquiry.Services;
using CustomerInquiry.Services.Implementation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerInquiry.WebApi
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            string connString = _configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<CustomerInquiryDbContext>(opt => opt.UseSqlServer(connString));

            services.AddTransient<ICustomerService, CustomerService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
