using System;
using System.Data.Entity;
using ElevenNote.Data;
using ElevenNote.WebApi.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElevenNote.Services;
using ElevenNote.Models;
using System.Linq;
using System.Web.Http.Results;

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
            _mockService = new MockNoteService();
            _controller = new NoteController(_mockService);
        }

        [TestMethod]
        public void NoteController_PostNote_ShouldReturnOk()
        {
            _mockService.ReturnValue = true;
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
    }
}
