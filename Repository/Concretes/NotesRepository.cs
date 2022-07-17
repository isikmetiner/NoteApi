using NoteAPI.Data;
using NoteAPI.Models;
using NoteAPI.Repository.Abstracts;

namespace NoteAPI.Repository.Concretes
{
    public class NotesRepository : INotesRepository
    {
        private readonly DataContext _dataContext;
        public NotesRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public bool IsNoteExist(int id)
        {
            return _dataContext.Note.Any(x => x.Id == id);
        }

        public int GetNoteCount()
        {
            return _dataContext.Note.Count();
        }

        public ICollection<Note> GetAllNotes()
        {
            return _dataContext.Note.ToList();
        }

        public Note GetNoteById(int id)
        {
            if (IsNoteExist(id))
                return _dataContext.Note.FirstOrDefault(x => x.Id == id);
            return null;
        }

        public ICollection<Note> GetNotesByUserId(int userId)
        {
            return _dataContext.Note.Where(x => x.UserId == userId).ToList();
        }

        public void CreateNote(Note note)
        {
            _dataContext.Add(note);
            _dataContext.SaveChanges();
        }

        public void UpdateNote(Note note)
        {
            _dataContext.Update(note);
            _dataContext.SaveChanges();
        }

        public void DeleteNote(Note note)
        {
            _dataContext.Remove(note);
            _dataContext.SaveChanges();
        }
    }
}
