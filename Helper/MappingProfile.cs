using NoteAPI.Models;
using NoteAPI.DateTransferObjects;

namespace NoteAPI.Helper
{
    public static class MappingProfile
    {
        public static NotesDto NoteMap(this Note note)
        {
            return new NotesDto
            {
                Text = note.Text,
            };
        }

        public static Note NotesDtoMap(this NotesDto notesDto)
        {
            return new Note
            {
                Text = notesDto.Text,
                UserId = notesDto.UserId
            };
        }

        public static List<NotesDto> NoteMapList(this ICollection<Note> notes)
        {
            List<NotesDto> result = new List<NotesDto>();
            foreach (var item in notes)
            {
                NotesDto dtoItem = new NotesDto
                {
                    Text = item.Text
                };
                result.Add(dtoItem);
            }
            return result;
        }

        public static User UserMap(this UsersDto usersDto)
        {
            return new User
            {
                Username = usersDto.Username,
                Password = usersDto.Password
            };
        }
    }
}
