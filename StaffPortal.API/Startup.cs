//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using Microsoft.EntityFrameworkCore;
//using StaffPortal.API.Data;
////using UniversityPortal.API.Services;
//using StaffPortal.API.Services;

//namespace UniversityPortal.API
//{
//    public class Startup
//    {
//        public Startup(IConfiguration configuration)
//        {
//            Configuration = configuration;
//        }

//        public IConfiguration Configuration { get; }

//        public void ConfigureServices(IServiceCollection services)
//        {
//            // Configure DbContext
//            services.AddDbContext<ApplicationDbContext>(options =>
//                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

//            // Register services
//            services.AddScoped<IStaffService, StaffService>();
//            services.AddScoped<IGenderService, GenderService>();
//            services.AddScoped<IQualificationService, QualificationService>();

//            services.AddControllers();
//        }

//        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//        {
//            if (env.IsDevelopment())
//            {
//                app.UseDeveloperExceptionPage();
//                app.UseSwagger();
//                app.UseSwaggerUI();
//            }

//            app.UseHttpsRedirection();

//            app.UseRouting();

//            app.UseAuthorization();

//            app.UseEndpoints(endpoints =>
//            {
//                endpoints.MapControllers();
//            });
//        }
//    }
//}
