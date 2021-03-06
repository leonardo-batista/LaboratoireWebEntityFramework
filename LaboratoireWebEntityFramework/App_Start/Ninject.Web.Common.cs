[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(LaboratoireWebEntityFramework.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(LaboratoireWebEntityFramework.App_Start.NinjectWebCommon), "Stop")]

namespace LaboratoireWebEntityFramework.App_Start
{
    using System;
    using System.Web;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using Infrastructure;
    using log4net;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            //�a marche tr�s bien
            kernel.Bind<LaboratoireContext>()
                .ToSelf()
                .InRequestScope()
                .Named("LaboratoireContext");

            log4net.Config.XmlConfigurator.Configure();
            var loggerPourWebSite = LogManager.GetLogger("LoggerEcommerce");
            kernel.Bind<ILog>().ToConstant(loggerPourWebSite).Named("LoggerPourWebSite");

            //kernel.Get<LaboratoireContext>("LaboratoireContext");

            //kernel.Bind<LaboratoireContext>()
            //    .ToSelf()
            //    .InSingletonScope()
            //    .Named("LaboratoireContext");
            //kernel.Get<LaboratoireContext>("LaboratoireContext");

            //kernel.Bind<LaboratoireContext>().ToSelf().InRequestScope().Named("LaboratoireContext");
            //kernel.Bind(typeof(IRepositoryContext<>)).To(typeof(RepositoryContext<>)).InRequestScope().Named("RepositoryContext");
        }
    }
}