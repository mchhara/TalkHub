using System.ComponentModel.DataAnnotations;

namespace TalkHub.Models
{
	public class Message
	{
		public int Id { get; set; }
		[Required]
		public string UserName { get; set; }
		[Required]
		public string Text { get; set; }
		public DateTime When { get; set; }
		public int UserId { get; set; }
		public virtual AppUser AppUser { get; set; }	
	}
}
