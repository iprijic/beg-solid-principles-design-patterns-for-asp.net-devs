﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

using Microsoft.AspNet.Http;
using Microsoft.Net.Http.Headers;
using System.IO;
using Mediator.Core;

using Microsoft.AspNet.Hosting;
using Newtonsoft.Json;

namespace Iterator.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void Login([FromBody]ChatUser usr)
        {
            ChatRoom room = new ChatRoom();
            IParticipant participant = new Participant(usr.Name, room);
            room.Login(participant);
        }

        [HttpPost]
        public void Logout([FromBody]ChatUser usr)
        {
            ChatRoom room = new ChatRoom();
            IParticipant participant = new Participant(usr.Name, room);
            room.Logout(participant);
        }

        [HttpPost]
        public IActionResult Send([FromBody]ChatMessage msg)
        {
            ChatRoom room = new ChatRoom();
            IParticipant sender = room.GetParticipant(msg.From);
            IParticipant receiver = room.GetParticipant(msg.To);
            if (receiver != null)
            {
                sender.Send(msg.To, msg.Message);
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }

        [HttpPost]
        public IActionResult GetHistory([FromBody]ChatUser usr)
        {
            ChatRoom room = new ChatRoom();
            IParticipant participant = room.GetParticipant(usr.Name);
            if (participant != null)
            {
                return Json(participant.GetChatHistory());
            }
            else
            {
                return Json("");
            }
        }

    }
}
