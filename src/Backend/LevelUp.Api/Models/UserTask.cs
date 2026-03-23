namespace LevelUp.Api.Models
{
    public class UserTask
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;       // Название дела
        public string Description { get; set; } = string.Empty; // Описание

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? Deadline { get; set; }                 // Когда надо закончить

        public bool IsCompleted { get; set; } = false;          // Выполнено или нет
        public bool IsBoss { get; set; } = false;               // Босс ли это?

        // Очки, которые даст задача (заполнит нейронка)
        public int RewardStrength { get; set; }
        public int RewardIntelligence { get; set; }
        public int RewardCharisma { get; set; }
        public int RewardStamina { get; set; }
        public int RewardSpirit { get; set; }
    }
}
