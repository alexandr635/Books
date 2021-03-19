using Books.Application.Services;
using Books.DAL;
using Books.DAL.Repositories;
using Books.Domain.Interfaces;
using Books.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Books.WebAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));
                        
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IBookSeriesRepository, BookSeriesRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IBookStatusRepository, BookStatusRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();

            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IClaimService, ClaimService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<IConverterService, ConverterService>();
            services.AddScoped<IBookStatusService, BookStatusService>();
            services.AddScoped<IHashService, HashService>();

            services.AddAutoMapper(typeof(Application.MapperProfile));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie(options =>
               {
                   options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Index");
                   options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Account/Index");
               });

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Book}/{action=Index}/{id?}");
            });
        }
    }
}
