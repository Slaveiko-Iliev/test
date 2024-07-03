using System.ComponentModel.DataAnnotations;

namespace P02_FootballBetting.Data.Models;

public class Position
{
    [Key]
    public int PositionId { get; set; }

    [Required]
    public string Name { get; set; }

    public ICollection<Player> Players { get; set; }
}
