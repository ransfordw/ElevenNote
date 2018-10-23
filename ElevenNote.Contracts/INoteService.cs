using ElevenNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Contracts
{
    public interface INoteService
    {
        bool CreateNote(NoteCreate model);
        IEnumerable<NoteListItem> GetNotes();
        NoteDetail GetNoteById(int id);
        bool UpdateNote(NoteEdit model);
        bool DeleteNote(int id);
    }
}
