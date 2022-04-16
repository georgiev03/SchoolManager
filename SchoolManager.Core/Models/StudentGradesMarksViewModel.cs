namespace SchoolManager.Core.Models
{
    public class StudentGradesMarksViewModel
    {
        public string Subject { get; set; }

        public IEnumerable<double> Marks { get; set; }

        public double AvgMark { get; set; }
    }
}
