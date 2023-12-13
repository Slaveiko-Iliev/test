namespace UniversityCompetition.Models
{
    internal class TechnicalSubject : Subject
    {
        private const double _SubjectRate = 1.3;

        public TechnicalSubject(int subjectId, string subjectName) : base(subjectId, subjectName, _SubjectRate)
        {
        }
    }
}
