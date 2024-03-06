using MediatR;
using MemoVerse_Commends.Commend.NoteCommends.Commend;
using MemoVerse_Commends.Exceptions;
using MemoVerse_Database.SQLConnection;

namespace MemoVerse_Commends.Commend.NoteCommends.CommendHandler;

public class UpdateNoteHandler : IRequestHandler<UpdateNote>
{
    private readonly MemoDbContext context;
    public UpdateNoteHandler(MemoDbContext context)
    {
        this.context = context;
    }
    public async Task Handle(UpdateNote request, CancellationToken cancellationToken)
    {
        try
        {
            var note = await context.Notes.FindAsync(request.FromDto.Id);
            if (note == null) throw new NotFoundException("Note Not Found");
            note.Title = request.FromDto.Title;
            note.Text = request.FromDto.Text;
            note.UpdateDate = DateTime.Now;
            context.Notes.Update(note);
            await context.SaveChangesAsync(cancellationToken);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
