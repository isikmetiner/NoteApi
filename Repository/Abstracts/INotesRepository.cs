using NoteAPI.Models;

namespace NoteAPI.Repository.Abstracts
{
    public interface INotesRepository
    {
        bool IsNoteExist(int id);
        int GetNoteCount();
        ICollection<Note> GetAllNotes();
        Note GetNoteById(int id);
        ICollection<Note> GetNotesByUserId(int userId);
        void CreateNote(Note note);
        void UpdateNote(Note note);
        void DeleteNote(Note note);
    }
}
