using TestCases.Models.BaseModels;

namespace TestCases.Models
{
    public class TestCase_Role : IDTestCaseID
    {
        public int RoleID { get; set; }
        public virtual Role? Role { get; set; }
    }
}
