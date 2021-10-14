using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Backend.Models;
using Backend.Services;

namespace Backend.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class TextController : ControllerBase
  {
    public TextController()
    {
    }

    [HttpGet]
    public ActionResult<Text> Get() => TextService.Get();
  }
}