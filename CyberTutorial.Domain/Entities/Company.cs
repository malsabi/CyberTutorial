namespace CyberTutorial.Domain.Entities
{
    public class Company
    {
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string OwnerFirstName { get; set; }
        public string OwnerLastName { get; set; }
        public string OwnerEmiratesId { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string State { get; set; }
        public string Region { get; set; }
        public string StreetAddress { get; set; }
        public string Website { get; set; }
        public string CompanyDescription { get; set; }
        public string Password { get; set; }
        public CompanySession Session { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}