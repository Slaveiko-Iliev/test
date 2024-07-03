using FootballBetting.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models;

public class Game
{
    [Key]
    public int GameId { get; set; }

    public int HomeTeamId { get; set; }

    [ForeignKey(nameof(HomeTeamId))]
    public Team HomeTeam { get; set; }

    public int AwayTeamId { get; set; }

    [ForeignKey(nameof(AwayTeamId))]
    public Team AwayTeam { get; set; }

    public int HomeTeamGoals { get; set; }

    public int AwayTeamGoals { get; set; }

    public decimal HomeTeamBetRate { get; set; }

    public decimal AwayTeamBetRate { get; set; }

    public decimal DrawBetRate { get; set; }

    public DateTime DateTime { get; set; }

    [Required]
    [MaxLength(ValidationConstants.ResultMaxLength)]
    public string Result { get; set; }

    public ICollection<Player> Player { get; set; }

    public ICollection<Bet> Bets { get; set; }
}
