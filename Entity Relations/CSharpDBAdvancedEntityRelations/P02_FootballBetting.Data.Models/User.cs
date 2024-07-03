using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models;

public class User
{
    [Key]
    public int UserId { get; set; }

    [Required]
    [Column(TypeName = "varchar(100)")]
    public string Name { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(20)")]
    public string Username { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(20)")]
    public string Password { get; set; }

    [Column(TypeName = "varchar(20)")]
    public string Email { get; set; }

    public decimal Balance { get; set; }

    public ICollection<Bet> Bets { get; set; }
}
