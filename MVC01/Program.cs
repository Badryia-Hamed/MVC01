using MVC01.Middelwares;
using static System.Net.Mime.MediaTypeNames;

namespace MVC01
{
    public class Program
    {
        public static void Main(string[] args)
        {

            #region SessionConcepts
            // Concepts: 
            // 1. Create Builder       --> var builder = WebApplication.CreateBuilder(args);
            // 2. Add Needed-Services  --> builder.Services.AddControllersWithViews();
            //                         --> builder.Services.AddControllers();
            //                         --> builder.Services.AddRazorPages();
            // ##Services## Without It The App Will not Run : It's needed For The CLR, And important For Routing 
            // 3. Build Application --> var app = builder.Build();
            // 4. Add MiddelWares 
            // ## Action## Must to be [public] [Non-Static] Methods 
            // ## ActionResult | IActionResult ##
            // ## Helper Method ##
            // CreacteBilder --> Create obj from WebApplicationBilder
            // Bilder --> By Using it I can add services i need in my appllication
            // The services i need can be added in the services Container (Which is a Function) 
            #endregion

            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.
            // Used to Add The Built-in [Wep MVC Services] to Container 

            // DI Controller --> CLR Used To Create Objects From The Controlers You Have InWhich You reache to the Action you want. 
            builder.Services.AddControllersWithViews();

            // Used to Add The Built-in [Wep APIs Services] to Container 
            //builder.Services.AddControllers();

            // Used to Add The Built-in [Wep Razor Services] to Container 
            //builder.Services.AddRazorPages();


            //Build the app
            var app = builder.Build();


            // Middelwares (Piplines) : Gates Or Layers inWhich the Requests & Response Path
            // Requests & Response are Functions 
            // Middelwares Like : Authentication , Authorization , StaticFiles
            // PipeLine Must FLow By Order 
            //         ExeptionHandling First
            //         StaticFiles Before Routing
            //         Authorization After Routing

            #region Custom Middelware
            // Custom Middelware
            // 1 ....
            //app.Use(async (context, next) =>
            //{
            //    Console.WriteLine("Hello");
            //    await next.Invoke(context);
            //    Console.WriteLine("ByeBye");
            //});
            // 2 ....
            //app.UseMiddleware<RequestTimeMiddelware>(); 
            #endregion

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();    // Check Premissions
            //app.UseAuthentication(); // Check Login
            app.MapStaticAssets();

            //app.MapControllerRoute(
            //    name : "defualt2",
            //    pattern : "shop/{controller}/{action}"
            //    );
            // Routing Convention
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
