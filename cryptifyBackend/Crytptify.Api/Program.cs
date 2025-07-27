using Cryptify.Application;
using Crytptify.Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApi(builder.Configuration).AddApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapOpenApi();
app.UseSwagger();
app.UseSwaggerUI();
//app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("AllowSpecificOrigins");

app.MapControllers();

await app.RunAsync();
