using System.Data;
using TestCases.Models;
using TestCases.Models.BaseModels;

namespace TestCases.ViewModels
{
    public class TestCaseViewModel
    {
        public class CheckList
        {
            public bool IsChecked { get; set; } = false;
            public int Id { get; set; } = 0;
            public string Description { get; set; } = string.Empty;
        }
        public TestCase TestCase { get; set; }
        public List<Role> Roles { get; set; }
        public List<BusinessUnit> BusinessUnits { get; set; }
        public List<CheckList> RolesChecked { get; set; } = new List<CheckList>();
        public List<CheckList> BusinessUnitsChecked { get; set; } = new List<CheckList>();

        public TestCaseViewModel(TestCase testCase, List<Role> roles, List<BusinessUnit> businessUnits)
        {
            TestCase = testCase;
            Roles = roles;
            BusinessUnits = businessUnits;
            
            foreach(IDDescription role in Roles)
            {
                AddToCheckListHelper(role, RolesChecked);
            }
            foreach(IDDescription businessUnit in BusinessUnits)
            {
                AddToCheckListHelper(businessUnit, BusinessUnitsChecked);
            }
            if(TestCase.Roles is not null)
            {
                foreach(TestCase_Role item in TestCase.Roles)
                {
                    RolesChecked.First(a => a.Id.Equals(item.RoleID)).IsChecked = true;
                }
            }
            if(TestCase.BusinessUnits is not null)
            {
                foreach(TestCase_BusinessUnit item in TestCase.BusinessUnits)
                {
                    BusinessUnitsChecked.First(a=>a.Id.Equals(item.BusinessUnitID)).IsChecked = true;   
                }
            }
        }
        private void AddToCheckListHelper (IDDescription entity, List<CheckList> checkLists)
        {
            CheckList checkList = new CheckList
            {
                Description = entity.Description,
                Id = entity.Id
            };
            checkLists.Add(checkList);
        }
    }
}
