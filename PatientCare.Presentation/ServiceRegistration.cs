using Carter;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace PatientCare.Presentation;

public static class ServiceRegistration
{
    public static void AddPresentationLayer(this IServiceCollection services, IConfiguration configuration)
    {
        #region Scalar
          
        #endregion
        
        //Agregamos carter para que revise los endpoint 
            services.AddCarter();
    }
}
