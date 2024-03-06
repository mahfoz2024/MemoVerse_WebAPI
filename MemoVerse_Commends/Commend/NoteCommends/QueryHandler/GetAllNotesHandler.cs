using MediatR;
using MemoVerse_Commends.Commend.NoteCommends.Query;
using MemoVerse_Database.SQLConnection;
using MemoVerse_Models.Models;
using Microsoft.EntityFrameworkCore;

namespace MemoVerse_Commends.Commend.NoteCommends.QueryHandler;

public class GetAllNotesHandler : IRequestHandler<GetAllNotes, IEnumerable<Note>>
{
    private readonly MemoDbContext context;
    public GetAllNotesHandler(MemoDbContext context)
    {
        this.context = context;
    }
    public async Task<IEnumerable<Note>> Handle(GetAllNotes request, CancellationToken cancellationToken)
    {
        try
        {
            return await context.Notes.ToListAsync(cancellationToken);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
