using Microsoft.AspNetCore.Mvc;
using Hangfire;


[Route("api/[controller]")]
[ApiController]
public class ExcelUploadController : ControllerBase
{
    private readonly ExcelProcessingService _excelProcessingService;

    public ExcelUploadController(ExcelProcessingService excelProcessingService)
    {
        _excelProcessingService = excelProcessingService;
    }

    [HttpPost]
    public async Task<IActionResult> UploadExcelFile(IFormFile file)
    {
        if (file.Length == 0)
        {
            return BadRequest("No file uploaded.");
        }

        if (file.ContentType != "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
        {
            return BadRequest("Invalid file type. Only Excel files are allowed.");
        }

        // Save the file temporarily
        var tempFilePath = Path.GetTempFileName();
        await using (var stream = new FileStream(tempFilePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        // Enqueue background job to process the Excel file
        var jobId = BackgroundJob.Enqueue(() => _excelProcessingService.ProcessExcelFile(tempFilePath));

        return Accepted(new { Message = "File uploaded successfully", JobId = jobId });
    }
}