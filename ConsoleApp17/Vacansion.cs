namespace ConsoleApp17
{
    internal class Vacansion
    {

        public Guid VacansionId { get; set; }
        public string? VacansionName { get; set; }
        public string? VacansionText { get; set; }
        public DateTime? VacansionTime { get; set; }
        public List<CV> Cvc { get; set; } = new();

        public Vacansion(Guid vacansionId, string? vacansionName, string? vacansionText, DateTime? vacansionTime)
        {
            VacansionId = vacansionId;
            VacansionName = vacansionName;
            VacansionText = vacansionText;
            VacansionTime = vacansionTime;
        }

        public Vacansion()
        {
            VacansionId = Guid.Empty;
            VacansionName = default;
            VacansionText = default;
            VacansionTime = default;
        }


        public override string ToString()
        {
            return @$"Vacansion ID{VacansionId}
Name Vacansion=>{VacansionName}
Text Vacamsion=>{VacansionText}
Date Time Vacansion=>{VacansionTime}";
        }
    }
}
