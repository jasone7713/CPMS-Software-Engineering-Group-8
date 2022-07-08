namespace CPMS.Models
{
    public class Author
    {
        public int AuthorID { get; set; }
        public string? FirstName { get; set; }
        public char? MiddleInitial { get; set; }
        public string? LastName { get; set; }
        public string? Affiliation { get; set; }
        public string? Department { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
        public string? PhoneNumber { get; set; }
        public string? EmailAddress { get; set; }
        public string? Password { get; set; }

        public Author()
        {

        }
    }
}
