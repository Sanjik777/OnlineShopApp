﻿using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using OnlineShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services
{
	public class FirebaseNotificationService : INotificationService
	{
		public async Task SendInformMessage(List<string> ids, string message)
		{
			var app = FirebaseApp.Create(new AppOptions()
			{
				Credential = GoogleCredential.GetApplicationDefault(),
			});

			List<Message> messages = new List<Message>();
			foreach (var id in ids)
			{

				messages.Add(new Message
				{
					Token = id,
					//			Data = new Dictionary<string, string>
					//{
					//	{ "message",message }
					//},
					Notification = new Notification
					{
						Title = "уведомление",
						Body = message
					}
				});
			}
			await FirebaseMessaging.DefaultInstance.SendAllAsync(messages);			
		}
	}
}
