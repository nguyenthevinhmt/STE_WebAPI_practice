using System.ComponentModel.DataAnnotations;

namespace JWT_test.Dto.Student
{
    public class CardDto
    {
        
        public int Id { get; set; }
        public int CardId { get; set; }
        [Required]
        public string CardType { get; set; }
    }
}
