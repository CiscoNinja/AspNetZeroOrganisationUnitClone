using Abp;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Organizations;
using AspNetZeroOrganisationUnitClone.Authorization;
using AspNetZeroOrganisationUnitClone.MyOrganizationUnit.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetZeroOrganisationUnitClone.MyOrganizationUnit
{
    //[AbpAuthorize(PermissionNames.Pages_OrganizationUnits)]
    public class OrganizationUnitAppService : AsyncCrudAppService<OrganizationUnit, MyOrganizationUnitDto, long, PagedAndSortedResultRequestDto, CreateMyOrganizationUnitDto, MyOrganizationUnitDto>, IOrganisationUnitAppService
    {
        private readonly IRepository<OrganizationUnit, long> _organizationUnitRepository;
        private readonly IRepository<UserOrganizationUnit, long> _userOrganizationUnitRepository;
        private readonly OrganizationUnitManager _OrganizationUnitManager;

        public OrganizationUnitAppService(IRepository<OrganizationUnit, long> repository,
            IRepository<OrganizationUnit, long> organizationUnitRepository,
            IRepository<UserOrganizationUnit, long> userOrganizationUnitRepository,
            OrganizationUnitManager OrganizationUnitManager
            )
            : base(repository)
        {
            _organizationUnitRepository = organizationUnitRepository;
            _userOrganizationUnitRepository = userOrganizationUnitRepository;
            _OrganizationUnitManager = OrganizationUnitManager;
        }

        public async Task<ListResultDto<MyOrganizationUnitDto>> GetOUs()
        {
            var ous = await _organizationUnitRepository.GetAllListAsync();
            return new ListResultDto<MyOrganizationUnitDto>(ObjectMapper.Map<List<MyOrganizationUnitDto>>(ous));
        }

        public virtual void CreateOU(CreateMyOrganizationUnitDto organizationUnit)
        {
            CheckCreatePermission();
            var ou = ObjectMapper.Map<OrganizationUnit>(organizationUnit);
            _OrganizationUnitManager.Create(ou);
            CurrentUnitOfWork.SaveChanges();
        }

        public async Task<OUListDto> GetByIDAsync(long id)
        {
            var organizationUnit = await Repository.GetAsync(id);

            if (organizationUnit == null)
            {
                throw new EntityNotFoundException(typeof(OrganizationUnit), id);
            }

            //return new SubjectDto
            //{
            //    Semester = subject.Semester.Name,
            //    Courses = subject.CourseSubjects.Select(x => x.Course.Name).ToList(),
            //    Levels = subject.SubjectLevels.Select(x => x.Level.Name).ToList()
            //};

            return new OUListDto
            {
                Id = organizationUnit.Id,
                Data = organizationUnit.DisplayName,
                CollapsedIcon = "pi pi-folder",
                ExpandedIcon = "pi pi-folder-open",
                Label = organizationUnit.DisplayName,
                ParentID = organizationUnit.ParentId
            };
        }

        //public override async Task<OrganizationUnitDto> CreateAsync(CreateOrganizationUnitDto organizationUnit)
        //{
        //    CheckCreatePermission();

        //    var ou = ObjectMapper.Map<OrganizationUnit>(organizationUnit);
        //    await _OrganizationUnitManager.CreateAsync(ou);
        //    CurrentUnitOfWork.SaveChanges();

        //    return MapToEntityDto(ou);
        //}

        //public virtual void Update(OrganizationUnit organizationUnit)
        //{
        //    _OrganizationUnitManager.Update(organizationUnit);
        //}

        public override async Task<MyOrganizationUnitDto> UpdateAsync(MyOrganizationUnitDto organizationUnit)
        {
            CheckUpdatePermission();

            var ou = await Repository.GetAsync(organizationUnit.Id);
            if (ou != null)
            {
                MapToEntity(organizationUnit, ou);

                await _OrganizationUnitManager.UpdateAsync(ou);

                CurrentUnitOfWork.SaveChanges();
            }
           

            return await GetAsync(organizationUnit);
        }

        //public virtual void Delete(long id)
        //{
        //    _OrganizationUnitManager.Delete(id);
        //}

        public override async Task DeleteAsync(EntityDto<long> input)
        {
            CheckDeletePermission();

            await _OrganizationUnitManager.DeleteAsync(input.Id);

        }

        //public async Task FillOuWithGrcUnitsAsync()
        //{
        //    await _MYOrganizationUnitManager.CreateOuStructure();
        //}

        public List<OUListDto> GetFileStructure()
        {
            List<OUListDto> list = new List<OUListDto>();

            var newlist = Repository.GetAllList().OrderBy(x => x.DisplayName).Select(model => new OUListDto
            {
                Id = model.Id,
                Data = model.DisplayName,
                CollapsedIcon = "pi pi-folder",
                ExpandedIcon = "pi pi-folder-open",
                Label = model.DisplayName,
                ParentID = model.ParentId,
                Leaf = false,
            }).ToList();

            list = new List<OUListDto>(ObjectMapper.Map<List<OUListDto>>(newlist));

            List<OUListDto> treelist = new List<OUListDto>();
            if (list.Count > 0)
            {
                treelist = BuildTree(list);
            }

            return new List<OUListDto>(ObjectMapper.Map<List<OUListDto>>(treelist));
        }

        //Recursion method for recursively get all child nodes
        public void GetTreeview(List<OUListDto> list, OUListDto current, List<OUListDto> returnList)
        {
            //get child of current item
            var childs = list.Where(a => a.ParentID == current.Id).ToList();
            current.Children = new List<OUListDto>();
            current.Children.AddRange(childs);
            foreach (var i in childs)
            {
                GetTreeview(list, i, returnList);
            }
        }

        public List<OUListDto> BuildTree(List<OUListDto> list)
        {
            List<OUListDto> returnList = new List<OUListDto>();
            //find top levels items
            var topLevels = list.Where(a => a.ParentID == list.OrderBy(b => b.ParentID).FirstOrDefault().ParentID).AsQueryable();
            returnList.AddRange(topLevels);
            foreach (var i in topLevels)
            {
                GetTreeview(list, i, returnList);
            }
            return new List<OUListDto>(ObjectMapper.Map<List<OUListDto>>(returnList));
        }

    }
}
