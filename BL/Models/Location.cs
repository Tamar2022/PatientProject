namespace CoronaApp.Services
{
    public class Location
    {
        public int PatientId { get; set; }
        public string City { get; set; }
        public string TheLocation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate
        {
            get; set;
        }
    }
}
