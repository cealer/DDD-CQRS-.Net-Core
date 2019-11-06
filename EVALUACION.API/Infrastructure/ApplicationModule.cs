using Autofac;
using EVALUACION.API.Application.Commands;
using EVALUACION.API.Application.Queries;
using EVALUACION.DOMAIN.AggregatesModel.OCAggregate;
using EVALUACION.DOMAIN.AggregatesModel.OCAggregate._HP_OC_DET_DET;
using EVALUACION.INFRASTRUCTURE.Repositories;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace EVALUACION.API.Infrastructure
{
    public class ApplicationModule
      : Autofac.Module
    {
        public string QueriesConnectionString { get; }
        public IHostingEnvironment _env { get; set; }

        public ApplicationModule(string qconstr, IHostingEnvironment env)
        {
            QueriesConnectionString = qconstr;
            _env = env;
        }

        protected override void Load(ContainerBuilder builder)
        {

            builder.Register(c => new OCQueries(QueriesConnectionString, _env))
                .As<IOCQueries>()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(CREAR_OC_COMMAND_HANDLER)
           .GetTypeInfo().Assembly);

            builder.RegisterAssemblyTypes(typeof(EDITAR_OC_COMMAND_HANDLER)
            .GetTypeInfo().Assembly);

            builder.RegisterAssemblyTypes(typeof(ELIMINAR_OC_COMMAND_HANDLER)
            .GetTypeInfo().Assembly);

            builder.RegisterType<HP_OC_Repository>()
           .As<IHP_OC_REPOSITORY>()
           .InstancePerLifetimeScope();

            builder.RegisterType<HP_OC_DET_Repository>()
.As<IHP_OC_DET_DET_REPOSITORY>()
.InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(CREAR_OC_COMMAND_HANDLER)
           .GetTypeInfo().Assembly);

            builder.RegisterAssemblyTypes(typeof(EDITAR_OC_COMMAND_HANDLER)
.GetTypeInfo().Assembly);
            builder.RegisterAssemblyTypes(typeof(ELIMINAR_OC_COMMAND_HANDLER)
.GetTypeInfo().Assembly);

        }
    }
}
