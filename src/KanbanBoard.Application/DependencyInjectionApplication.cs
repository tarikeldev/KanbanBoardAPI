﻿using KanbanBoard.Application.Interfaces.Auth;
using KanbanBoard.Application.Interfaces.Board;
using KanbanBoard.Application.Interfaces.Repositories.Auth;
using KanbanBoard.Application.Services.Auth;
using KanbanBoard.Application.Services.Board;
using KanbanBoard.Application.Services.Tasks;
using KanbanTask.Application.Interfaces.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace KanbanBoard.Application
{
    public static class DependencyInjectionApplication
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IBoardService, BoardService>();
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<IUserService, UserService>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }
    }
}
