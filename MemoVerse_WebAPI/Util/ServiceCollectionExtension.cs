using MediatR;
using MemoVerse_Commends.Commend.NoteCommends.Commend;
using MemoVerse_Commends.Commend.NoteCommends.CommendHandler;
using MemoVerse_Commends.Commend.NoteCommends.Query;
using MemoVerse_Commends.Commend.NoteCommends.QueryHandler;
using MemoVerse_Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace MemoVerse_WebAPI.Util;

public static class ServiceCollectionExtension
{
    #region Base Settings
    public static void ConfigureControllers(this IServiceCollection services)
    {
        _ = services.AddControllers(config =>
        {
            config.CacheProfiles.Add("30SecondsCaching", new CacheProfile
            {
                Duration = 30
            });
        });
    }
    public static void ConfigureResponseCaching(this IServiceCollection services)
    {
        services.AddResponseCaching();
    }
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        return services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
    }


    public static void ConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "MemoVeres API",
                Version = "v1",
                Description = "MemoVeres API Services.",
                Contact = new OpenApiContact
                {
                    Name = "Mahfoz Khalil ."
                },
            });
            c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme."
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] {}
            }
        });
        });
    }
    #endregion
    public static void AddCommendTransients(this IServiceCollection services)
    {
        services.TryAddScoped<IRequestHandler<AddNote, Note>, AddNoteHandler>();
        services.TryAddScoped<IRequestHandler<UpdateNote>, UpdateNoteHandler>();
        services.TryAddScoped<IRequestHandler<RemoveNote>, RemoveNoteHandler>();
        services.TryAddScoped<IRequestHandler<GetAllNotes, IEnumerable<Note>>, GetAllNotesHandler>();
        services.TryAddScoped<IRequestHandler<GetNote, Note>, GetNoteHandler>();
    }
}
