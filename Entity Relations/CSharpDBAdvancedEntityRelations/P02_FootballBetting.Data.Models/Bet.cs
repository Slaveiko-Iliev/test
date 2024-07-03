using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models;

public class Bet
{
    [Key]
    public int BetId { get; set; }

    public decimal Amount { get; set; }

    [Required]
    [Column(TypeName = "varchar(20)")]
    public string Prediction { get; set; }

    public DateTime DateTime { get; set; }

    public int UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public User User { get; set; }

    public int GameId { get; set; }

    [ForeignKey(nameof(GameId))]
    public Game Game { get; set; }
}
//⦁	Bet – BetId, Amount, Prediction, DateTime, UserId, GameId
