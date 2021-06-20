using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Civica.Core.BO;

namespace TestMVC.AutoMapper
{
    public class AutoMapperMapping : Profile
    {
        public AutoMapperMapping()
        {
            CreateMap<UserVm, UserBo>();
            CreateMap<UserBo, UserVm>();
        }
    }
}

