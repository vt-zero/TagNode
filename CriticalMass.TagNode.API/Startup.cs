using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;  
using TagNode.Extend;

namespace TagNode
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services){
            //跨域
            services.AddCors(options =>{
                options.AddPolicy("any", builder1 =>{
                    builder1.AllowAnyOrigin() //允许任何来源的主机访问
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();//指定处理cookie
                });
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //设置全局路由
            services.AddMvc(opt => {
                opt.UseCentralRoutePrefix(new RouteAttribute("api/[controller]/[action]"));
            });

            var builder = new ContainerBuilder();//实例化 AutoFac  容器
            var assemblys = System.Reflection.Assembly.Load("CriticalMass.TagNode.Repository");//CriticalMassTagNode.Repository是继承接口的实现方法类库名称
            var baseType = typeof(CriticalMass.TagNode.IRepository.IRepository);//IDependency 是一个接口（所有要实现依赖注入的借口都要继承该接口）
            builder.RegisterAssemblyTypes(assemblys).Where(m => baseType.IsAssignableFrom(m) && m != baseType).AsImplementedInterfaces().InstancePerLifetimeScope();
            //Transient： 每一次GetService都会创建一个新的实例
            //Scoped：  在同一个Scope内只初始化一个实例 ，可以理解为（ 每一个request级别只创建一个实例，同一个http request会在一个 scope内）
            //Singleton ：整个应用程序生命周期以内只创建一个实例
            builder.Populate(services);
            IContainer ApplicationContainer = builder.Build();
            return new AutofacServiceProvider(ApplicationContainer);//第三方IOC接管 core内置DI容器
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //跨域
            app.UseCors("any");
            app.Use(next => context => { context.Request.EnableRewind(); return next(context); });
            app.UseMvc();
        }
    }
}
