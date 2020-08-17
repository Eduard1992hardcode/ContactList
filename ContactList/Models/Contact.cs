using System.ComponentModel.DataAnnotations;

namespace ContactList.Models
{
    public class Contact
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Не указано имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Не указана Фамилия")]
        public string Surname { get; set; }
        public int TellNumber { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }

    }
}
