using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kanban.Models;

public class Card
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public string? Description { get; set; }
    
    public int ContainerId { get; set; }
    public Container Container { get; set; }
}