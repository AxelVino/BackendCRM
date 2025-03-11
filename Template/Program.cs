using Application.Interfaces;
using Application.Interfaces.IMappers;
using Application.Mappers;
using Application.UseCase.Campaign;
using Application.UseCase.Clients;
using Application.UseCase.Interaction;
using Application.UseCase.InteractionType;
using Application.UseCase.Projects;
using Application.UseCase.Tasks;
using Application.UseCase.TaskStatus;
using Application.UseCase.User;
using Infrastructrure.Command;
using Infrastructrure.Persistence;
using Infrastructrure.Querys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        builder => builder
            .WithOrigins("http://127.0.0.1:5500")
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuration

var connectionString = builder.Configuration["ConnectionString"];
builder.Services.AddDbContext<CrmDbContext>(options => options.UseSqlServer(connectionString));

//---------

builder.Services.AddScoped<IClientsService, ClientsServices>();
builder.Services.AddScoped<IClientsQuery, ClientsQuery>();
builder.Services.AddScoped<IClientsCommand, ClientsCommand>();
builder.Services.AddScoped<IClientsMapper, ClientMapper>();

builder.Services.AddScoped<ICampaignService, CampaignServices>();
builder.Services.AddScoped<ICampaignQuery, CampaignQuerys>();
builder.Services.AddScoped<ICampaignMapper, CampaignMapper>();

builder.Services.AddScoped<ITaskStatusServices, TaskStatusServices>();
builder.Services.AddScoped<ITaskStatusQuerys, TaskStatusQuerys>();
builder.Services.AddScoped<IStatusTaskMapper, StatusTaskMapper>();

builder.Services.AddScoped<ITasksMapper, TasksMapper>();
builder.Services.AddScoped<ITasksService, TasksService>();
builder.Services.AddScoped<ITasksQuery, TasksQuery>();
builder.Services.AddScoped<ITasksCommand, TasksCommand>();

builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IUserQuery, UserQuerys>();

builder.Services.AddScoped<IInteractionsMapper, InteractionsMapper>();
builder.Services.AddScoped<IInteractionsQuery, InteractionsQuery>();
builder.Services.AddScoped<IInteractionService, InteractionService>();
builder.Services.AddScoped<IInteractionCommand, InteractionCommand>();

builder.Services.AddScoped<IInteractionTypeServices, InteractionTypeServices>();
builder.Services.AddScoped<IInteractionTypeQuery, InteractionTypeQuerys>();
builder.Services.AddScoped<IInteractionTypeMapper, InteractionTypeMapper>();


builder.Services.AddScoped<IProjectServices, ProjectServices>();
builder.Services.AddScoped<IProjectCommand, ProjectCommand>();
builder.Services.AddScoped<IProjectQuery, ProjectQuery>();
builder.Services.AddScoped<IProjectMapper, ProjectMapper>();

builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IUserQuery, UserQuerys>();
builder.Services.AddScoped<IUsersMapper, UsersMapper>();



var app = builder.Build();

app.UseCors("AllowLocalhost");

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
