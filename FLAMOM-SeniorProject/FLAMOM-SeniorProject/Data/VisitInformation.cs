namespace FLAMOM_SeniorProject.Data
{
    public class VisitInformation
    {
        public int Id { get; set; }
        public bool MouthPain { get; set; }

        public string LengthOfPain { get; set; }

        public string OverallHealth { get; set; }

        public string TimeToTravel { get; set; }

        public string AttendBefore { get; set; }
        /// <summary>
        /// we use public virtual List<> because of the one to many relationship, both of these tables are the same for this reason
        /// </summary>
        public virtual List<ReasonForVisit> ReasonsForVisit { get; set; }
        public virtual List<HeardAbout> HeardAbouts { get; set; }

    }
}
