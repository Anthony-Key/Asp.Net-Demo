using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_AK.Models
{
    [Table("Movies")]
    public class Movie
    {
        [Key]
        public int mId { get; set; }
        public string mName { get; set; }
    }
}
