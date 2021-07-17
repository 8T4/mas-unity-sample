using MasUnity.HealthCheck.Configuration;
using MasUnity.HostedService.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MyBusiness.Compliance.AnalysisAfterPurchase.Agents.CreditRisk;
using MyBusiness.Compliance.AnalysisAfterPurchase.Agents.CreditRisk.Actions;
using MyBusiness.Compliance.AnalysisAfterPurchase.Agents.CreditRisk.Environments;
using MyBusiness.Compliance.AnalysisAfterPurchase.Agents.CreditRisk.Knowledges;
using MyBusiness.Compliance.Configuration;

namespace MyBusiness.Compliance
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEfServices();
            services.AddSwaggerServices();
            services.AddHealthCheckServices();
            services.AddControllers();               

            services.ConfigureMasUnity((option) =>
            {
                option.AddAgent<CreditRiskAgent>(2)
                    .WithSchedule<CreditRiskAgentSchedule>()
                    .WithEnvironment<PendingTransactions>()
                    .WithKnowledge<AboutCreditCardTransactionAfter20Pm>()
                    .WithKnowledge<AboutCreditCardTransactionBetween8AmAnd20Pm>()
                    .WithAction<AllowCreditCardTransaction>()
                    .WithAction<DenyCreditCardTransaction>()
                    .WithAction<DenyCreditCardTransactionAfter20Pm>()
                    .WithHealtCheck()
                    .Build();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.ConfigureSwagger();
            app.ConfigureHealthCheck();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/hc");
                endpoints.MapHealthChecksUI();
            });            
        }
    }
}