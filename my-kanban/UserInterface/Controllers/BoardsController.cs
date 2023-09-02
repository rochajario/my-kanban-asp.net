using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System.Diagnostics;
using UserInterface.Models;

namespace UserInterface.Controllers
{
    public class BoardsController : Controller
    {
        private readonly ILogger<BoardsController> _logger;
        private readonly IBoardService _boardService;

        public BoardsController(ILogger<BoardsController> logger, IBoardService boardService)
        {
            _logger = logger;
            _boardService = boardService;
        }

        public IActionResult Index()
        {
            ViewBag.Boards = _boardService.GetAllBoards();
            return View();
        }

        public IActionResult NewBoard(string boardName, string boardDescription)
        {
            _boardService.CreateBoard(new BoardDto()
            {
                Name = boardName,
                Description = boardDescription
            });
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}