using System.ComponentModel.DataAnnotations;

namespace NoteAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public ICollection<Note> Notes { get; set; }
    }
}
