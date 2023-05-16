using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JWT_test.Models
{
    public class LibraryCard
    {
        [ForeignKey("student")]
        public int Id { get; set; }
        public int CardId { get; set; }
        public string CardType { get; set; }
        
        public virtual Student Student { get;}
    }
}
