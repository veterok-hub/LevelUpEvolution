namespace LevelUp.Api.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Slayer"; // Имя твоего героя

        // Характеристики
        public int Strength { get; set; } = 0;      // Сила
        public int Intelligence { get; set; } = 0;  // Интеллект
        public int Charisma { get; set; } = 0;      // Харизма
        public int Stamina { get; set; } = 0;       // Выносливость
        public int Spirit { get; set; } = 0;        // Дух
        public int Discipline { get; set; } = 0;    // Дисциплина

        // Уровень и Опыт
        public int Level { get; set; } = 1;
        public int CurrentExperience { get; set; } = 0;
        public int ExperienceToNextLevel { get; set; } = 100; // Порог уровня
    }
}
