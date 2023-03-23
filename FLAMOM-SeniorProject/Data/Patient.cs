namespace FLAMOM_SeniorProject.Data
{
    public class Patient
    {
        public int Id { get; set; }
        public string UniquePatientId { get; set; }
        public bool MouthPain { get; set; }

        public string? LengthOfPain { get; set; }

        public string OverallHealth { get; set; }

        public string TimeToTravel { get; set; }

        public string AttendBefore { get; set; }
        /// <summary>
        /// we use public virtual List<> because of the one to many relationship, both of these tables are the same for this reason
        /// </summary>
        public virtual List<ReasonForVisit> ReasonsForVisit { get; set; }
        public virtual List<HeardAbout> HeardAbouts { get; set; }
        public string? OtherAnswer { get; set; }


        public string TeethGums { get; set; }
        public string MainRsn { get; set; }
        public string LastVisit { get; set; }
        public string MainRsnLstVst { get; set; }
        public string UsualCare { get; set; }
        public string Emrgncy { get; set; }
        public string? LastSixMnths { get; set; }
        public string? GoToOffice { get; set; }
        public string UsualJobs { get; set; }
        public string Insurance { get; set; }
        public virtual List<OtherReasonsForVisit> OtherReasonsForVisit { get; set; }
        public string? OtherAnswer2 { get; set; }
        public virtual List<DentalOfficesVisited> DentalOfficesVisited { get; set; }
        public virtual List<Tobacco> Tobaccos { get; set; }


        public string LevelOfSchool { get; set; }
        public virtual List<KindOfHealthcare> KindOfHealthcare { get; set; }
        public string ServedInMil { get; set; }
        public string Hispanic { get; set; }
        public virtual List<PatientRace> PatientRace { get; set; }
        public string JobSituation { get; set; }


        public string PeopleAtHome { get; set; }
        public string FoodStamp { get; set; }
        public string WicProg { get; set; }
        public string HouseIncome { get; set; }

        public static string GenerateUniqueId()
        {
            var guid = Guid.NewGuid();
            var bytes = guid.ToByteArray();
            long longValue = BitConverter.ToInt64(bytes, 0);
            return longValue.ToString("X").Substring(0, 6);
        }
    }
}
