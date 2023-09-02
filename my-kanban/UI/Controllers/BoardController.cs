using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace UI.Controllers
{
    public class BoardController : Controller
    {
        private readonly IBoardService _boardService;
        private readonly ITaskService _taskService;

        public BoardController(IBoardService boardService, ITaskService taskService)
        {
            _boardService = boardService;
            _taskService = taskService;
        }

        [HttpGet("{id}")]
        [ActionName("Index")]
        public IActionResult Index(string id)
        {
            var boardData = _boardService.GetBoardWithChildrenTasks(Convert.ToInt32(id));
            ViewBag.BoardData = boardData;
            return View();
        }

        [HttpPost("{id}")]
        [ActionName("NewTask")]
        public IActionResult NewTask(string id)
        {
            _boardService.AddTask(Convert.ToInt32(id), new TaskDto()
            {
                Name = HttpContext.Request.Form["Name"],
                Description = HttpContext.Request.Form["Description"]
            });
            return RedirectToAction("Index", id);
        }
    }
}
