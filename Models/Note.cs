using System.ComponentModel.DataAnnotations;

namespace NoteAPI.Models
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
    }
}
