using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_AK.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool isSubscribedToNewsLetter { get; set; }
		public MembershipType Membership { get; set; }
		public byte MembershipId { get; set; }
	}
}
