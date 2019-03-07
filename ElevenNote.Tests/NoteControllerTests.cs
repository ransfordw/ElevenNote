using System;
using System.Data.Entity;
using ElevenNote.Data;
using ElevenNote.WebApi.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElevenNote.Services;
using ElevenNote.Models;
using System.Linq;
using System.Web.Http.Results;
using System.Collections.Generic;

namespace ElevenNote.Tests
{
    [TestClass]
    public class NoteControllerTests
    {
        private NoteController _controller;
        private MockNoteService _mockService;

        [TestInitialize]
        public void Arrange()
        {
            _mockService = new MockNoteService { ReturnValue = true };
            _controller = new NoteController(_mockService);
        }

        [TestMethod]
        public void NoteController_PostNote_ShouldReturnOk()
        {
            var note = new NoteCreate
            {
                ClassSubject = "Math",
                Content = "Stuff about math",
                Title = "Algebra",
            };

            var result = _controller.Post(note);

            Assert.IsInstanceOfType(result, typeof(OkResult));
            Assert.AreEqual(1, _mockService.CallCount);
        }

        [TestMethod]
        public void NoteController_DeleteNote_ShouldReturnCorrectInt()
        {
            _mockService.CallCount = 1;

            var result = _controller.Delete(1);

            Assert.AreEqual(0, _mockService.CallCount);
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void NoteController_GetAllNotes_CountShouldBeCorrectInt()
        {
            var result = _controller.GetAll();

            Assert.AreEqual(1, _mockService.CallCount);
            Assert.IsInstanceOfType(
                result,
                typeof(OkNegotiatedContentResult<IEnumerable<NoteListItem>>)
                );
        }

        [TestMethod]
        public void NoteController_GetNoteByID_CountShouldBeCorrectInt()
        {
            var result = _controller.Get(1);

            Assert.AreEqual(1, _mockService.CallCount);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<NoteDetail>));
        }

        [TestMethod]
        public void NoteController_UpdateNote_ShouldDo()
        {
            var note = new NoteEdit
            {
                ClassSubject = "Maths",
                Content = "Stuff about math",
                Title = "Algebra",
            };

            var result = _controller.Put(note);

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void NoteController_UpdateNote_ShouldNotDo()
        {
            _mockService.ReturnValue = false;
            var note = new NoteEdit
            {
                ClassSubject = "Maths",
                Content = "Stuff about math",
            };
            var result = _controller.Put(note);

            Assert.IsNotInstanceOfType(result, typeof(OkResult));
        }
    }
}
