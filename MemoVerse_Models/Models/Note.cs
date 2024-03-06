using System.ComponentModel.DataAnnotations;

namespace MemoVerse_Models.Models;

public class Note
{
    [Key]
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Text { get; set; }
    public DateTime CreationDate { get; set; } = DateTime.Now;
    public DateTime UpdateDate { get; set; }
}
