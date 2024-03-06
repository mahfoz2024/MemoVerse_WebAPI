using MediatR;
using MemoVerse_Models.Models;

namespace MemoVerse_Commends.Commend.NoteCommends.Query;

public record GetAllNotes() : IRequest<IEnumerable<Note>>;
public record GetNote(Guid Id) : IRequest<Note>;
