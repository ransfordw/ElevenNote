using ElevenNote.Contracts;
using ElevenNote.Models;
using ElevenNote.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ElevenNote.WebApi.Controllers
{
    [Authorize]
    public class NoteController : ApiController
    {
        public NoteController(INoteService mockService)
        {
            _noteService = mockService;
        }

        public NoteController()
        {
            _noteService = CreateNoteService();
        }

        public IHttpActionResult GetAll()
        {
            var notes = _noteService.GetNotes();
            return Ok(notes);
        }

        public IHttpActionResult Get(int id)
        {
            var note = _noteService.GetNoteById(id);
            return Ok(note);
        }

        public IHttpActionResult Post(NoteCreate note)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_noteService.CreateNote(note))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(NoteEdit note)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_noteService.UpdateNote(note))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            if (!_noteService.DeleteNote(id))
                return InternalServerError();

            return Ok();
        }

        private NoteService CreateNoteService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new NoteService(userID);
            return service;
        }

        private INoteService _noteService;
    }
}
