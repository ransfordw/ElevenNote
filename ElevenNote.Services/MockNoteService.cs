using ElevenNote.Contracts;
using ElevenNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Services
{
    public class MockNoteService : INoteService
    {
        public bool ReturnValue { get; set; }
        public int CallCount { get; set; }

        public bool CreateNote(NoteCreate model)
        {
            CallCount++;
            return ReturnValue;
        }

        public bool DeleteNote(int id)
        {
            CallCount--;
            return ReturnValue;
        }

        public NoteDetail GetNoteById(int id)
        {
            CallCount++;
            return new NoteDetail { NoteID = id };
        }

        public IEnumerable<NoteListItem> GetNotes()
        {
            CallCount++;
            var @return = new List<NoteListItem> { new NoteListItem { NoteID = 1 } };
            return @return;
        }

        public bool UpdateNote(NoteEdit model)
        {
            return ReturnValue;
        }
    }
}
