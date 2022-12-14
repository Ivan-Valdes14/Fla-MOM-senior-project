namespace FLAMOM_SeniorProject.Data
{
    public class HeardAbout
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public string HeardAboutHow { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
