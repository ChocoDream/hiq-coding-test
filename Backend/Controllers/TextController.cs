using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
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

    public IActionResult UploadFile(IFormFile file)
    {
      TextService.processFile(file);
      return CreatedAtAction(nameof(UploadFile), new { value = "success" });
    }
  }
}