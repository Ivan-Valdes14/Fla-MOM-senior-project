namespace FLAMOM_SeniorProject.Data
{
    public class Tobacco
    {
        public int Id { get; set; }

        public int PatientId { get; set; }
        public string Type { get; set; }
        /// <summary>
        /// This public virtual VisitInformation VisitInfo { get; set; } indicates there is a forgein key relation 
        /// declaring with a type of VisitInformation means its going to be a forgien key from that table and naming it VisitInfo implies that it will
        /// be linked to our visitInfoId
        /// If we do not use the proiper conventions then we need to tag the line above our foreign key with  [ForeignKey("NameOfTheTable")]
        /// </summary>
        public virtual Patient Patient { get; set; }
    }
}
