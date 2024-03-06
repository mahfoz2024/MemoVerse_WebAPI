namespace MemoVerse_DTO.Note;

public record NoteDto(Guid Id, string Title, string Text, DateTime CreationDate, DateTime UpdatedDate);
public record NoteFromDto(string Title, string Text);
public record NoteUpdateFromDto(Guid Id, string Title, string Text);
