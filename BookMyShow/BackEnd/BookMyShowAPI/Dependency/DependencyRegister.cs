using Autofac;
using BookMyShowAPI.Services.ContactServices;
using BookMyShowAPI.Services.MovieServices;
using BookMyShowAPI.Services.TicketServices;
using BookMyShowAPI.Services.AuthenticationServices;
namespace BookMyShowAPI.Dependency
{
    public class DependencyRegister : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MovieService>().As<IMovieService>().InstancePerLifetimeScope();
            builder.RegisterType<TicketService>().As<ITicketService>().InstancePerLifetimeScope();
           builder.RegisterType<ContactService>().As<IContactService>().InstancePerLifetimeScope();
            builder.RegisterType<AutenticateService>().As<IAuthenticateService>().InstancePerLifetimeScope();
        }
    }
}
