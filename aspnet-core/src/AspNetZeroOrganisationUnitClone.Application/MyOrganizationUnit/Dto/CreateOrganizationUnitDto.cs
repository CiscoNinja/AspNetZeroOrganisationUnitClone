using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Organizations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AspNetZeroOrganisationUnitClone.MyOrganizationUnit.Dto
{
    public class CreateOrganizationUnitDto : FullAuditedEntityDto<long>, IMayHaveTenant
    {
        //
        // Summary:
        //     TenantId of this entity.
        public virtual int? TenantId
        {
            get;
            set;
        }

        //
        // Summary:
        //     Parent Abp.Organizations.OrganizationUnit. Null, if this OU is root.
        [ForeignKey("ParentId")]
        public virtual OrganizationUnit Parent
        {
            get;
            set;
        }

        //
        // Summary:
        //     Parent Abp.Organizations.OrganizationUnit Id. Null, if this OU is root.
        public virtual long? ParentId
        {
            get;
            set;
        }

        //
        // Summary:
        //     Hierarchical Code of this organization unit. Example: "00001.00042.00005". This
        //     is a unique code for a Tenant. It's changeable if OU hierarch is changed.
        [StringLength(95)]
        public virtual string Code
        {
            get;
            set;
        }

        //
        // Summary:
        //     Display name of this role.
        [Required]
        [StringLength(128)]
        public virtual string DisplayName
        {
            get;
            set;
        }

    }
}
