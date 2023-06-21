using Microsoft.AspNetCore.SignalR;
using TalkHub.Models;

namespace TalkHub.Hubs
{
	public class ChatHub : Hub
	{
		public async Task SendMessage(Message message) =>
			await Clients.All.SendAsync("receiveMessage", message);

	}
}
