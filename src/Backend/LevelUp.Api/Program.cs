using LevelUp.Api.Models; // Добавил эту строчку, чтобы наш контроллер знал о Character и UserTask

var builder = WebApplication.CreateBuilder(args);

// Добавляем сервисы для твоего API
builder.Services.AddControllers(); // Это критично для работы твоих контроллеров (CharacterController)
builder.Services.AddEndpointsApiExplorer(); // Нужно для Swagger
builder.Services.AddSwaggerGen(); // Включаем генератор Swagger документации

// Настройка CORS (чтобы фронтенд мог общаться с бэкендом)
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin() // Разрешаем запросы с любого адреса (пока что, потом ограничим)
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});


var app = builder.Build();

// Конфигурируем HTTP запрос
// Мы ВЫНОСИМ Swagger ИЗ if (app.Environment.IsDevelopment()), чтобы он работал всегда
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors(); // Добавляем CORS-политику

app.UseAuthorization();

app.MapControllers(); // Это КРИТИЧНО - говорит серверу "найди все контроллеры и используй их"

app.Run();
