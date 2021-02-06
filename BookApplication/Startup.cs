using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Data;
using Microsoft.EntityFrameworkCore;
using Application.Logic;
using Application;
using Data.Logic;

namespace BookApplication
{
    public class Startup
    {
        public IConfiguration configuration { get; }

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
{
            string connection = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<BookContext>(options => options.UseSqlServer(connection));

            services.AddScoped<IBookQuery, BookQuery>();
            services.AddScoped<IWorkWithBook, WorkWithBook>();
            services.AddScoped<IAuthorQuery, AuthorQuery>();
            services.AddScoped<IWorkWithAuthor, WorkWithAuthor>();
            services.AddScoped<IWorkWithGenre, WorkWithGenre>();
            services.AddScoped<IGenreQuery, GenreQuery>();
            services.AddScoped<IWorkWithTag, WorkWithTag>();
            services.AddScoped<ITagQuery, TagQuery>();
            services.AddScoped<IWorkWithSeries, WorkWithSeries>();
            services.AddScoped<ISeriesQuery, SeriesQuery>();
            services.AddScoped<IWorkWithReview, WorkWithReview>();
            services.AddScoped<IReviewQuery, ReviewQuery>();
            services.AddScoped<IStatusQuery, StatusQuery>();
            services.AddScoped<IWorkWithStatus, WorkWithStatus>();

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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=BookSeries}/{action=Index}/{id?}");
            });
        }
    }
}
