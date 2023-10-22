using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using TestCases.Models.BaseModels;

namespace TestCases.Models
{
    [Keyless]
    public class TestCase_Role
    {
        public int TestCaseId { get; set; }
        public int RoleID { get; set; }
        public virtual Role? Role { get; set; }
        public virtual TestCase? TestCase { get; set; }
    }
}
