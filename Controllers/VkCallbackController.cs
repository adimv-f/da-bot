using System;
using Microsoft.AspNetCore.Mvc;
using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;
using System.Text.RegularExpressions;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DaBot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VkCallbackController : Controller
    {
        private readonly IVkApi _vkApi;

        public VkCallbackController(IVkApi vkApi)
        {
            _vkApi = vkApi;
        }

        [HttpPost]
        public IActionResult ConfirmApi([FromBody]UpdateDTO request)
        {
            switch (request.Type)
            {
                case "confirmation":
                    if (request.GroupId == Config.ConfirmationGroupId)
                        return Ok(Config.Confirmation);
                    break;
                
                case "message_new":
                    var msg = Message.FromJson(new VkResponse(request.Object));

                    var regex = new Regex(@"да+[\W]*$", RegexOptions.Compiled);

                    MatchCollection matches = regex.Matches(msg.Text.ToLower());

                    int random = new Random().Next(100);

                    if (matches.Count == 1 && random > 50)
                    {
                        _vkApi.Messages.Send(new MessagesSendParams
                        {
                            PeerId = msg.PeerId.Value,
                            // Message = string.IsNullOrEmpty(msg.Text) ? "WRONG" : msg.Text,
                            Message = "Пизда",
                            RandomId = new Random().Next(),
                            ForwardMessages = new []{ msg.ConversationMessageId.Value }
                        });
                    }
                    

                    return Ok("ok");
            }

            return BadRequest();
        }
    }
}
