using Microsoft.AspNetCore.Mvc;
namespace GestionRapports.API.Controllers;
[ApiController]
[Route("api/pdf")]
public class UploadController : ControllerBase
{
    [HttpPost("upload")]
    public async Task<IActionResult> UploadFile(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            Console.WriteLine("No file uploaded.");
            return BadRequest("No file uploaded.");
        }
        try
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles", file.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            Console.WriteLine("File uploaded successfully at: " + filePath);
            return Ok(new { message = "File uploaded successfully", filePath });
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during file upload: " + ex.Message);
            return StatusCode(500, "Internal server error");
        }
    }
}