using NoteAPI.Helper;
using NoteAPI.Models;
using NoteAPI.Service.Abstract;
using NoteAPI.DateTransferObjects;
using NoteAPI.Repository.Abstracts;

namespace NoteAPI.Service.Concretes
{
    public class NotesService : INotesService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly INotesRepository _notesRepository;

        public NotesService(IUsersRepository usersRepository, INotesRepository notesRepository)
        {
            _usersRepository = usersRepository;
            _notesRepository = notesRepository;
        }

        public int GetNoteCount()
        {
            return _notesRepository.GetNoteCount();
        }

        public ICollection<NotesDto> GetAllNotes()
        {
            if (GetNoteCount() > 0)
            {
                ICollection<Note> notesList = _notesRepository.GetAllNotes();
                return notesList.NoteMapList();
            }
            return null;
        }

        public NotesDto GetNoteById(int id)
        {
            Note note = _notesRepository.GetNoteById(id);
            return note.NoteMap();
        }

        public ICollection<NotesDto> GetNotesByUserId(int id)
        {
            if (_usersRepository.IsUserExistId(id))
            {
                ICollection<Note> notesList = _notesRepository.GetNotesByUserId(id);
                return notesList.NoteMapList();
            }
            return null;
        }

        public ICollection<NotesDto> GetNotesByUsername(string username)
        {
            User foundUser = _usersRepository.GetUserByUsername(username);
            if (foundUser != null)
            {
                ICollection<Note> notesList = _notesRepository.GetNotesByUserId(foundUser.Id);
                return notesList.NoteMapList();
            }
            return null;
        }

        public void CreateNote(int userId, Note note)
        {
            if (_usersRepository.IsUserExistId(userId))
            {
                User foundUser = _usersRepository.GetUserById(userId);
                note.UserId = foundUser.Id;
                foundUser.Notes.Add(note);
                _notesRepository.CreateNote(note);
            }
        }

        public void UpdateNote(int userId, int noteId, Note note)
        {
            if (_usersRepository.IsUserExistId(userId))
            {
                User foundUser = _usersRepository.GetUserById(userId);
                if (_notesRepository.IsNoteExist(noteId))
                {
                    Note foundNote = _notesRepository.GetNoteById(noteId);
                    foundNote.Text = note.Text;
                    _notesRepository.UpdateNote(foundNote);
                }
            }
        }

        public void DeleteNote(int userId, int noteId)
        {
            if (_usersRepository.IsUserExistId(userId))
            {
                User foundUser = _usersRepository.GetUserById(userId);
                foundUser.Notes = _notesRepository.GetNotesByUserId(userId);
                if (_notesRepository.IsNoteExist(noteId))
                {
                    Note foundNote = foundUser.Notes.FirstOrDefault(x => x.Id == noteId);
                    _notesRepository.DeleteNote(foundNote);
                }
            }
        }
    }
}
