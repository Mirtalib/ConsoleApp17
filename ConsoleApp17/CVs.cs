
namespace ConsoleApp17
{
    [Serializable]
    class CV
    {
        public Guid Idcv { get; set; }
        public string? Specialty { get; set; }
        public string? School { get; set; }
        public int Admission_ball { get; set; }
        public DateTime? StartWork { get; set; }
        public DateTime? EndWork { get; set; }

        public List<string?>? Companies { get; set; } = new();
        public string? Language { get; set; }
        public string? Language_level { get; set; }
        // 
        public string? MessageEmployer { get; set; }
        public bool Honors_diploma { get; set; }

        public CV(Guid id, string? specialty, string? school, int admission_ball,
            DateTime? startWork, DateTime? endWork,
            List<string?> companies,
            string language,
            string? language_level,
            bool honors_diploma)
        {
            Idcv = id;
            Specialty = specialty;
            School = school;
            Admission_ball = admission_ball;
            StartWork = startWork;
            EndWork = endWork;

            Companies = companies;
            Language = language;

            Honors_diploma = honors_diploma;

            Language_level = language_level;
        }

        public CV()
        {
            Specialty = default;
            School = default;

            Admission_ball = default;
            StartWork = default;
            EndWork = default;
            Companies = default;
            Language = default;
            Honors_diploma = default;
        }


        public override string ToString()
        {
            return $@"Id Cv =>{Idcv}
Specialty=>{Specialty}
School=>{School}
Admission ball=>{Admission_ball}
StartWork=>{StartWork}
EndWork=>{EndWork}
Language=>{Language}
Language Level{Language_level}
Honors diploma=>{Honors_diploma}";
        }
    }
}
