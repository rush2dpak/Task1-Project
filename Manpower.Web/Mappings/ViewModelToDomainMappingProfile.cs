using AutoMapper;
using Manpower.Entities;
using Manpower.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Manpower.Web.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public virtual string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {

            
            Mapper.Initialize(r => { r.CreateMap<RoleViewModel, Role>(); });
            Mapper.Initialize(r => { r.CreateMap<DataRecordViewModel, DataRecord>(); });


        }

    }
}