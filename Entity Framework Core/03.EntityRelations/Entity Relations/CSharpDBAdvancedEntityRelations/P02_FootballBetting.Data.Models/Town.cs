using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models;

public class Town
{
    public Town()
    {
        this.Teams = new HashSet<Team>();
        this.Players = new HashSet<Player>();
    }

    [Key]
    public int TownId { get; set; }

    [Required]
    public string Name { get; set; }

    public int CountryId { get; set; }

    [ForeignKey(nameof(CountryId))]
    public Country Country { get; set; }

    public virtual ICollection<Team> Teams { get; set; }
    public virtual ICollection<Player> Players { get; set; }
}
