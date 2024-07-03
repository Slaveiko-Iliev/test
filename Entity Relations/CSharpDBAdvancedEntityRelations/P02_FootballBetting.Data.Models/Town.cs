using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models;

public class Town
{
    [Key]
    public int TownId { get; set; }

    [Required]
    public string Name { get; set; }

    public int CountryId { get; set; }

    [ForeignKey(nameof(CountryId))]
    public Country Country { get; set; }

    public ICollection<Team> Teams { get; set; }
    public ICollection<Player> Players { get; set; }
}
