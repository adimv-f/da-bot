using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DaBot.Controllers
{
    [Route("api/[controller]")]
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
                    _vkApi.Messages.Send(new MessagesSendParams
                    {
                        PeerId = long.Parse(request.Object.GetProperty("peer_id").ToString()),
                        Message = "понял принял",
                        RandomId = new Random().Next()
                    });
                    break;
            }
            
            return Ok();
        }
    }
}
