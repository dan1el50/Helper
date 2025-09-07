namespace AutumnBlazorApp.Shared.DTOs
{
    public class HumanDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public required string PlaceOfBirth { get; set; }
        public int Age { get; set; }
    }
}
