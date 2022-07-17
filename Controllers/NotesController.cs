using NoteAPI.Models;
using NoteAPI.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace NoteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : Controller
    {
        private readonly INotesService _noteService;

        public NotesController(INotesService service)
        {
            _noteService = service;
        }

        [HttpGet]
        [Route("GetNoteCount")]
        public IActionResult GetNoteCount()
        {
            return Ok(_noteService.GetNoteCount());
        }

        [HttpGet]
        [Route("GetAllNotes")]
        public IActionResult GetAllNotes()
        {

            return Ok(_noteService.GetAllNotes());
        }

        [HttpGet]
        [Route("GetNoteById/{id}")]
        public IActionResult GetNoteById(int id)
        {
            return Ok(_noteService.GetNoteById(id));
        }

        [HttpGet]
        [Route("GetNotesByUserId/{userId}")]
        public IActionResult GetNotesByUserId(int userId)
        {
            return Ok(_noteService.GetNotesByUserId(userId));
        }

        [HttpGet]
        [Route("GetNotesByUsername/{username}")]
        public IActionResult GetNotesByUsername(string username)
        {
            return Ok(_noteService.GetNotesByUsername(username));
        }

        [HttpPost]
        [Route("CreateNote")]
        public void CreateNote(int userId, Note note)
        {
            _noteService.CreateNote(userId, note);
        }

        [HttpPut]
        [Route("UpdateNote")]
        public void UpdateNote(int userId, int noteId, Note note)
        {
            _noteService.UpdateNote(userId, noteId, note);
        }

        [HttpDelete]
        [Route("DeleteNote")]
        public void DeleteNote(int userId, int noteId)
        {
            _noteService.DeleteNote(userId, noteId);
        }
    }
}
