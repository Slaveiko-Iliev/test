using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models;

public class Color
{
    [Key]
    public int ColorId { get; set; }

    [Required]
    public string Name { get; set; }

    [InverseProperty("PrimaryColor")]
    public ICollection<Team> PrimaryColorsTeams { get; set; }
    [InverseProperty("SecondaryColor")]
    public ICollection<Team> SecondaryColorsTeam { get; set; }
}
