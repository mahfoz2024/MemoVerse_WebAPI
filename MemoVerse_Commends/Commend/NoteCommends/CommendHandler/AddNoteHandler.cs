using MediatR;
using MemoVerse_Commends.Commend.NoteCommends.Commend;
using MemoVerse_Database.SQLConnection;
using MemoVerse_Models.Models;

namespace MemoVerse_Commends.Commend.NoteCommends.CommendHandler;

public class AddNoteHandler : IRequestHandler<AddNote, Note>
{
    private readonly MemoDbContext context;
    public AddNoteHandler(MemoDbContext context)
    {
        this.context = context;
    }
    public async Task<Note> Handle(AddNote request, CancellationToken cancellationToken)
    {
        try
        {
            Note note = new()
            {
                Title = request.FromDto.Title,
                Text = request.FromDto.Text,
            };
            await context.Notes.AddAsync(note);
            await context.SaveChangesAsync(cancellationToken);
            return note;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
