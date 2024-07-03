using FootballBetting.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models;

public class Team
{
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
    public Color PrimaryColor { get; set; }

    public int SecondaryKitColorId { get; set; }

    [ForeignKey(nameof(SecondaryKitColorId))]
    public Color SecondaryColor { get; set; }

    public int TownId { get; set; }

    [ForeignKey(nameof(TownId))]
    public Town Town { get; set; }

    public ICollection<Player> Players { get; set; }

    [InverseProperty("HomeTeam")]
    public ICollection<Game>GamesInHome { get; set; }

    [InverseProperty("AwayTeam")]
    public ICollection<Game> GuestGames { get; set; }
}
