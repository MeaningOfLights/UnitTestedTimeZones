using Vivet.AspNetCore.RequestTimeZone.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddLogging(config =>                 //<-- added
{
    config.AddDebug();
    config.AddConsole();
    //etc
});
builder.Services.AddRequestTimeZone(x =>             //<-- added
{
    // Configure options here
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseRequestTimeZone();   //<-- added

app.MapControllers();

app.Run();
