using AutoMapper;
using Manpower.Entities;
using Manpower.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Manpower.Web.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public virtual string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
           
            base.CreateMap<User, UserViewModel>().ReverseMap();
            base.CreateMap<Role, RoleViewModel>().ReverseMap();
            base.CreateMap<DataRecord, DataRecordViewModel>().ReverseMap();



        }
    }
}