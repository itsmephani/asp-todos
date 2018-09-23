using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace todos.Models
{
    public class Todo
    {
        // Used column type as SERIAL in pg to auto generate id value in db.
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("is_done")]
        public bool IsDone { get; set; }
    }
}
