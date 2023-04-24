using System.ComponentModel.DataAnnotations;

namespace AspCrud.Models.Domain
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
    }
}
