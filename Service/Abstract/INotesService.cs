using NoteAPI.Models;
using NoteAPI.DateTransferObjects;

namespace NoteAPI.Service.Abstract
{
    public interface INotesService
    {
        int GetNoteCount();
        ICollection<NotesDto> GetAllNotes();
        NotesDto GetNoteById(int id);
        ICollection<NotesDto> GetNotesByUserId(int id);
        ICollection<NotesDto> GetNotesByUsername(string username);
        void CreateNote(int userId, Note note);
        void UpdateNote(int userId, int noteId, Note note);
        void DeleteNote(int userId, int noteId);
    }
}
