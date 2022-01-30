using Abp.Organizations;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetZeroOrganisationUnitClone.MyOrganizationUnit.Dto
{
    public class OUMapProfile : Profile
    {
        public OUMapProfile()
        {
            CreateMap<OrganizationUnit, OrganizationUnitDto>().ReverseMap();
            CreateMap<CreateOrganizationUnitDto, OrganizationUnit>().ReverseMap();
        }
    }
}
