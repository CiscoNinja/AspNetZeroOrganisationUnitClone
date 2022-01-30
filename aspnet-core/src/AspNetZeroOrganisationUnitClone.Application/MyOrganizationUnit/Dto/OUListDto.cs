using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetZeroOrganisationUnitClone.MyOrganizationUnit.Dto
{
    public class OUListDto : EntityDto<long>
    {
        public string Label { get; set; }
        public string Data { get; set; }
        public long? ParentID { get; set; }
        public string ExpandedIcon { get; set; }
        public string CollapsedIcon { get; set; }
        public List<OUListDto> Children { get; set; }
        public bool? Leaf { get; set; } = false;
        public bool? Expanded { get; set; } = false;
        public string Type { get; set; }
        public OUListDto Parent { get; set; }
        public bool? PartialSelected { get; set; } = false;
        public string StyleClass { get; set; }
        public bool? Draggable { get; set; } = false;
        public bool? Droppable { get; set; } = false;
        public bool? Selectable { get; set; } = false;
        public string Key { get; set; }
    }
}
