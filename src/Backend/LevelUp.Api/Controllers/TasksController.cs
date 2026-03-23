using Microsoft.AspNetCore.Mvc;
using LevelUp.Api.Models;

namespace LevelUp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // Адрес будет: api/tasks
    public class TasksController : ControllerBase
    {
        // Временная заглушка для задач (пока нет базы)
        private static List<UserTask> _tasks = new List<UserTask>
        {
            new UserTask { Id = 1, Title = "Начать прокачку", Description = "Встать и сделать зарядку", RewardStrength = 5 },
            new UserTask { Id = 2, Title = "Изучить C#", Description = "Прочитать 10 страниц кода", RewardIntelligence = 10 }
        };

        // GET: api/tasks
        [HttpGet]
        public ActionResult<IEnumerable<UserTask>> GetTasks()
        {
            return Ok(_tasks);
        }

        // GET: api/tasks/{id} (получить одну задачу по ID)
        [HttpGet("{id}")]
        public ActionResult<UserTask> GetTask(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound(); // Если задачи с таким ID нет
            }
            return Ok(task);
        }

        // POST: api/tasks (добавить новую задачу)
        [HttpPost]
        public ActionResult<UserTask> AddTask([FromBody] UserTask newTask)
        {
            if (newTask == null || string.IsNullOrEmpty(newTask.Title))
            {
                return BadRequest("Не удалось добавить задачу. Убедитесь, что у нее есть название.");
            }

            // Присваиваем ID (в реальном приложении это будет делать база данных)
            newTask.Id = _tasks.Any() ? _tasks.Max(t => t.Id) + 1 : 1;
            _tasks.Add(newTask);

            // Возвращаем созданную задачу и статус 201 Created
            return CreatedAtAction(nameof(GetTask), new { id = newTask.Id }, newTask);
        }
    }
}
