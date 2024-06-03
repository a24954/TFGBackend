using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TFGBackend.Models;


public class Sesion
{
    [Key]
    public int IdSesion { get; set; }
    [Required]
    public string SesionTime { get; set; }

    public DateTime SesionDate  { get; set; }

    public int IdPista { get; set; }

    public bool Reservado { get; set; }

    [ForeignKey("IdPista")]
    public Pista Pista { get; set; }
}
