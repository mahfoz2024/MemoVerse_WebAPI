using MediatR;
using MemoVerse_DTO.Note;
using MemoVerse_Models.Models;

namespace MemoVerse_Commends.Commend.NoteCommends.Commend;

public record AddNote(NoteFromDto FromDto) : IRequest<Note>;
public record UpdateNote(NoteUpdateFromDto FromDto) : IRequest;
public record RemoveNote(Guid Id) : IRequest;
