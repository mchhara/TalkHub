﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TalkHub.Data;
using TalkHub.Models;

namespace TalkHub.Controllers
{
	public class HomeController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly UserManager<AppUser> _userManager;
		public HomeController(ApplicationDbContext context, UserManager<AppUser> userManager)
		{
			_context = context;
			_userManager = userManager;
		}

		public async Task <IActionResult> Index()
		{
			var currentUser = await _userManager.GetUserAsync(User);
			if(currentUser != null)
			{
                ViewBag.CurrentUserName = currentUser.UserName;
            }

            var messages = await _context.Messages.ToListAsync();
			return View();
		}

		public async Task<IActionResult> Create(Message message)
		{
			{
				message.UserName = User.Identity.Name;
				var sender = await _userManager.GetUserAsync(User);
				message.UserId = sender.Id;
				await _context.Messages.AddAsync(message);
				await _context.SaveChangesAsync();
				return Ok();
			}
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}