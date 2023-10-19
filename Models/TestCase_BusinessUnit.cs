using TestCases.Models.BaseModels;

namespace TestCases.Models
{
    public class TestCase_BusinessUnit: IDTestCaseID
    {
        public int BusinessUnitID { get; set; }
        public virtual BusinessUnit? BusinessUnit { get; set; }
    }
}
