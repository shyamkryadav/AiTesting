using AiTesting;
using OpenAI_API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register OpenAiService with the API key
builder.Services.AddSingleton<OpenAiService>(provider => new OpenAiService("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"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
