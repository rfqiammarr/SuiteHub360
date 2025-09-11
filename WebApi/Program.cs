using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using RifqiAmmarR.SuiteHub360.WebApi.Middlewares;
using RifqiAmmarR.SuiteHub360.Application;
using RifqiAmmarR.SuiteHub360.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var errors = context.ModelState
            .Where(x => x.Value.Errors.Count > 0)
            .ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
            );

        var result = new
        {
            error = "Validation Failed",
            errors
        };

        return new BadRequestObjectResult(result);
    };
});

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Layers
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Middleware global exception
app.UseMiddleware<ExceptionHandlingMiddleware>();

// Swagger for dev
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();