using Microsoft.AspNetCore.Mvc;

namespace RafaelPassosApi.Controllers
{
    public class BaseController : Controller
    {
        protected new IActionResult Response(string msg, int? id = null)
        {
            if (id != null || id > 0)
            {
                return Ok(new
                {
                    success = true,
                    message = msg
                });
            }

            return BadRequest(new
            {
                success = false,
                message = msg
            });
        }
    }
}
