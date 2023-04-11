using Microsoft.AspNetCore.Mvc

var builder = WebApplication.CreateBuilder();

builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();


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
