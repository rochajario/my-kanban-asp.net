using Domain.Dtos;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System.Diagnostics;
using UI.Models;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBoardService _boardService;

        public HomeController(ILogger<HomeController> logger, IBoardService boardService)
        {
            _logger = logger;
            _boardService = boardService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Boards = _boardService.GetAllBoards();
            return View();
        }

        [HttpPost]
        [ActionName("NewBoard")]
        public IActionResult NewBoard()
        {
            _boardService.CreateBoard(new BoardDto()
            {
                Name = HttpContext.Request.Form["Name"],
                Description = HttpContext.Request.Form["Description"]
            });

            return RedirectToAction("Index");
        }

        [HttpGet("SetInactive/{id}")]
        [ActionName("SetInactiveState")]
        public IActionResult InactiveState([FromRoute]int id)
        {
            _boardService.SetBoardState(Convert.ToInt32(id), BoardState.Inactive);
            return RedirectToAction("Index");
        }

        [HttpGet("SetActive/{id}")]
        [ActionName("SetActiveState")]
        public IActionResult ActiveState(string id)
        {
            _boardService.SetBoardState(Convert.ToInt32(id), BoardState.Active);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}