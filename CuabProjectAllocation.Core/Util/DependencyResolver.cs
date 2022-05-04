﻿using CuabProjectAllocation.Core.Interface;
using CuabProjectAllocation.Core.Services;
using CuabProjectAllocation.Infrastructure.DAC;
using CuabProjectAllocation.Infrastructure.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuabProjectAllocation.Core.Util
{
    public class DependencyResolver
    {
        public static void AddServiceDependencies(IServiceCollection services)
        {
            //Repository Mapping
            services.AddScoped<IEntityRepository<ApplicationUser>, EntityRepository<ApplicationUser>>();
            services.AddScoped<IEntityRepository<Student>, EntityRepository<Student>>();


            //Service Managers
            services.AddScoped<IUserService, UserService>();
        }
    }
}
