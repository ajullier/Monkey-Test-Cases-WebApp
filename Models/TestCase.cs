using TestCases.Models.BaseModels;

namespace TestCases.Models
{
    public class TestCase : IDDescription
    {
        public int StateID { get; set; }
        public int ViewID { get; set; }
        public virtual State? State {get; set;}
        public string? DataSet { get; set; }
        public string? Steps { get; set; }
        public int StepsCounter { get; set; } = 0;
        public bool Automated { get; set; } = false;
        public string? Comments { get; set; }
        public virtual ICollection<TestCase_BusinessUnit>? BusinessUnits { get; set; }
        public virtual ICollection<TestCase_Role>? Roles { get; set; }
        public virtual View? View { get; set; }    
    }
}
