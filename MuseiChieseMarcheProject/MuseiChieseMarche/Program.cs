using MuseiChieseMarche.MCMSOAP;
using SoapCore; 
using System.ServiceModel; 

namespace MuseiChieseMarche
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Aggiunge i controller MVC
            builder.Services.AddControllersWithViews();

            // Aggiunge il supporto a SOAP
            builder.Services.AddSoapCore();

            // Registra il servizio SOAP come singleton
            builder.Services.AddSingleton<IComuneMarche, MuseiChieseMarcheCount>();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.UseSoapEndpoint<IComuneMarche>("/Soap/Comune.asmx",
                    new SoapEncoderOptions(),
                    SoapSerializer.DataContractSerializer);

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.Run("http://0.0.0.0:80");
        }
    }
}
