namespace FLAMOM_SeniorProject.Data
{
    public class HeardAbout
    {
        public int Id { get; set; }

        public int VisitInfoId { get; set; }

        public string HeardAboutHow { get; set; }

        public virtual VisitInformation VisitInfo { get; set; }
    }
}
