using SuggestionApp.DatabaseConnection;
using SuggestionApp.Interfaces;
using SuggestionApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<EmployeeDbContext>(); 
builder.Services.AddScoped<ITokenService,TokenManager>();
builder.Services.AddCors(option=>
{
    option.AddPolicy("EmployeesPolicy", builder =>
    {
        builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("EmployeesPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
