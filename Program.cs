using RazorDropDown.Data;
using RazorDropDown.Services;

namespace RazorDropDown
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddDbContext<OurDbContext>();

            /// http injection and use of app config
            builder.Services.AddHttpClient<EventTypeService1>();
            builder.Services.AddScoped<EventTypeService1>();


            // Set up and Register JokeApiService for Joke API
            builder.Services.AddHttpClient("JokeApiClient", client =>
            {
                client.BaseAddress = new Uri(builder.Configuration["ApiSettings:JokeApiBaseUrl"]);
            });
            builder.Services.AddScoped<JokeService>();


            
            // Register multiple HttpClients with different configurations
            builder.Services.AddHttpClient("EventTypeClient", client =>
            {
                client.BaseAddress = new Uri(builder.Configuration["ApiSettings:EventTypeBaseUrl"]);
            });
            builder.Services.AddScoped<NamedEventTypeService>();




            builder.Services.AddScoped<EntertainmentService>();
            
            builder.Services.AddScoped<EventTypeService>();
            builder.Services.AddSession();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
