using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EphemeralEnvironments.API.Entities
{
    [Table("vibes")]
    public class Vibes
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("vibe")]
        public string Vibe { get; set; } = String.Empty;
    }
}
