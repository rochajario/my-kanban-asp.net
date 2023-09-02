using Domain.Dtos;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace UserInterface.Controllers
{
    public class TasksController : Controller
    {
        private readonly IBoardService _boardService;
        private readonly ITaskService _taskService;

        public TasksController(IBoardService boardService, ITaskService taskService)
        {
            _boardService = boardService;
            _taskService = taskService;
        }

        public IActionResult Board(string boardId)
        {
            var id = Convert.ToInt32(boardId);
            ViewBag.BoardDetails = _boardService.GetBoardWithChildrenTasks(id);
            return View();
        }

        public IActionResult NewTask(string boardId, string taskName, string taskDescription)
        {
            _boardService.AddTask(
                Convert.ToInt32(boardId),
                new TaskDto()
                {
                    Name = taskName,
                    Description = taskDescription
                }
                );
            return RedirectToAction("Board", "Tasks", new { boardId });
        }

        public IActionResult SetToDoing(string taskId)
        {
            return AlterTaskState(taskId, TaskState.Doing);
        }
        public IActionResult SetToTodo(string taskId)
        {
            return AlterTaskState(taskId, TaskState.Todo);
        }
        public IActionResult SetToConcluded(string taskId)
        {
            return AlterTaskState(taskId, TaskState.Concluded);
        }
        public IActionResult SetToCanceled(string taskId)
        {
            return AlterTaskState(taskId, TaskState.Canceled);
        }
        private IActionResult AlterTaskState(string taskId, TaskState taskState) 
        {
            var boardId = _taskService.ChangeTaskState(Convert.ToInt32(taskId), taskState);
            return RedirectToAction("Board", "Tasks", new { boardId = boardId });
        }
    }
}
