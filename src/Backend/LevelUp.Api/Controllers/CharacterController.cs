using Microsoft.AspNetCore.Mvc;
using LevelUp.Api.Models;

namespace LevelUp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        // Временная переменная в памяти сервера (пока нет БД)
        private static Character _mainCharacter = new Character { Name = "New Hero" };

        // ПОЛУЧИТЬ персонажа (GET)
        [HttpGet]
        public ActionResult<Character> GetCharacter()
        {
            return Ok(_mainCharacter);
        }

        // ЗАДАТЬ имя персонажа (POST)
        [HttpPost("set-name")]
        public ActionResult<Character> SetName([FromBody] string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
            {
                return BadRequest("Имя не может быть пустым!");
            }

            _mainCharacter.Name = newName; // Меняем имя в памяти
            return Ok(_mainCharacter);    // Возвращаем обновленного героя
        }
    }
}

