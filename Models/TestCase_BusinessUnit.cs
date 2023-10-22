using Microsoft.EntityFrameworkCore;
using TestCases.Models.BaseModels;

namespace TestCases.Models
{
    [Keyless]
    public class TestCase_BusinessUnit
    {
        public int TestCaseID { get; set; }
        public int BusinessUnitID { get; set; }
        public virtual BusinessUnit? BusinessUnit { get; set; }
        public virtual TestCase? TestCase { get; set; }
    }
}
