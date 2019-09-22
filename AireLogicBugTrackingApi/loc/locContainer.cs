using Microsoft.Extensions.DependencyInjection;

namespace AireLogicBugTrackingApi.loc
{ 
    public static class IoC
    {
        public static ApplicationDbContext ApplicationDbContext => IoCContainer.Provider.GetService<ApplicationDbContext>();
    }

    public static class IoCContainer
    {
        public static ServiceProvider Provider { get; set; }
    }
}
