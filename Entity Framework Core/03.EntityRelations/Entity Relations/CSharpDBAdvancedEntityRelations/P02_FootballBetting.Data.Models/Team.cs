using FootballBetting.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models;

public class Team
{
    public Team()
    {
        this.Players = new HashSet<Player>();
        this.HomeGames = new HashSet<Game>();
        this.AwayGames = new HashSet<Game>();
    }

    [Key]
    public int TeamId { get; set; }

    [Required]
    [MaxLength(ValidationConstants.TeamNameMaxLength)]
    public string Name { get; set; } = null!;

    public string LogoUrl { get; set; }

    [Required]
    [MaxLength(ValidationConstants.TeamInitialsMaxLength)]
    public string Initials { get; set; } = null!;

    public decimal Budget { get; set; }

    public int PrimaryKitColorId { get; set; }

    [ForeignKey(nameof(PrimaryKitColorId))]
    public virtual Color PrimaryKitColor { get; set; }

    public int SecondaryKitColorId { get; set; }

    [ForeignKey(nameof(SecondaryKitColorId))]
    public virtual Color SecondaryKitColor { get; set; }

    public int TownId { get; set; }

    [ForeignKey(nameof(TownId))]
    public virtual Town Town { get; set; }

    public virtual ICollection<Player> Players { get; set; }

    [InverseProperty(nameof(Game.HomeTeam))]
    public virtual ICollection<Game> HomeGames { get; set; }

    [InverseProperty(nameof(Game.AwayTeam))]
    public virtual ICollection<Game> AwayGames { get; set; }
}
