using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VkNet.Abstractions;

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
            if (request.Type == "confirmation" && request.GroupId == Config.ConfirmationGroupId)
                return Ok(Config.Confirmation);

            return Ok("ok");
        }
    }
}
