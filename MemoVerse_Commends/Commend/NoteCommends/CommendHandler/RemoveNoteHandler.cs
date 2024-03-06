using MediatR;
using MemoVerse_Commends.Commend.NoteCommends.Commend;
using MemoVerse_Commends.Exceptions;
using MemoVerse_Database.SQLConnection;
namespace MemoVerse_Commends.Commend.NoteCommends.CommendHandler;

public class RemoveNoteHandler : IRequestHandler<RemoveNote>
{
    private readonly MemoDbContext context;
    public RemoveNoteHandler(MemoDbContext context)
    {
        this.context = context;
    }
    public async Task Handle(RemoveNote request, CancellationToken cancellationToken)
    {
        try
        {
            var note = await context.Notes.FindAsync(request.Id);
            if (note == null) throw new NotFoundException("Note Not Found");
            context.Notes.Remove(note);
            await context.SaveChangesAsync(cancellationToken);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
