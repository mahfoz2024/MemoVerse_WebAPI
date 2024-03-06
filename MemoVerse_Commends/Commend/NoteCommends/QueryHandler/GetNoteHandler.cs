using MediatR;
using MemoVerse_Commends.Commend.NoteCommends.Query;
using MemoVerse_Commends.Exceptions;
using MemoVerse_Database.SQLConnection;
using MemoVerse_Models.Models;

namespace MemoVerse_Commends.Commend.NoteCommends.QueryHandler;

public class GetNoteHandler : IRequestHandler<GetNote, Note>
{
    private readonly MemoDbContext context;
    public GetNoteHandler(MemoDbContext context)
    {
        this.context = context;
    }
    public async Task<Note> Handle(GetNote request, CancellationToken cancellationToken)
    {
        try
        {
            var note = await context.Notes.FindAsync(request.Id);
            if (note == null) throw new NotFoundException("Note Not Found");
            return note;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
