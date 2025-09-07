using System.ComponentModel.DataAnnotations.Schema;

namespace AutumnBlazorApp.Domain
{
    public class Human
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public required string PlaceOfBirth { get; set; }

        // This property will NOT be stored in the database.
        // It will be calculated on the fly whenever we need it.
        [NotMapped]
        public int Age
        {
            get
            {
                var today = DateTime.Today;
                var age = today.Year - DateOfBirth.Year;
                if (DateOfBirth.Date > today.AddYears(-age))
                {
                    age--;
                }
                return age;
            }
        }
    }
}
