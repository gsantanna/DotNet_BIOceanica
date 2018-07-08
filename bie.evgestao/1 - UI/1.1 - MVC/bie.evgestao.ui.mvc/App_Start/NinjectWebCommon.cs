[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(bie.evgestao.ui.mvc.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(bie.evgestao.ui.mvc.App_Start.NinjectWebCommon), "Stop")]

namespace bie.evgestao.ui.mvc.App_Start
{


    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    using application.Interfaces;
    using application;

    using domain.Interfaces.Service;
    using domain.Interfaces.Repository;
    using domain.Services;
    using infra.data.Repository;

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



            kernel.Bind(typeof(IAppServiceBase<>)).To(typeof(AppServiceBase<>));
            kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));



            kernel.Bind<INotificationAppService>().To<NotificationAppService>();



            //Usuario
            kernel.Bind<IUsuarioService>().To<UsuarioService>();
            kernel.Bind<IUsuarioAppService>().To<UsuarioAppService>();
            kernel.Bind<IUsuarioRepository>().To<UsuarioRepository>();

            //Pessoa
            kernel.Bind<IPessoaService>().To<PessoaService>();
            kernel.Bind<IPessoaAppService>().To<PessoaAppService>();
            kernel.Bind<IPessoaRepository>().To<PessoaRepository>();

            //Familiar
            kernel.Bind<IFamiliarService>().To<FamiliarService>();
            kernel.Bind<IFamiliarAppService>().To<FamiliarAppService>();
            kernel.Bind<IFamiliarRepository>().To<FamiliarRepository>();

            //Celula
            kernel.Bind<ICelulaService>().To<CelulaService>();
            kernel.Bind<ICelulaAppService>().To<CelulaAppService>();
            kernel.Bind<ICelulaRepository>().To<CelulaRepository>();





        }
    }






}
