using Hangfire;
using OfficeOpenXml;
using Xcelerate.Data;
using Xcelerate.Models;

public class ExcelProcessingService
{
    private readonly XDbContext _context;

    public ExcelProcessingService(XDbContext context) => _context = context;

    [AutomaticRetry(Attempts = 3)]
    public async Task ProcessExcelFile(string tempFilePath)
    {
        if (!System.IO.File.Exists(tempFilePath))
        {
            throw new FileNotFoundException("Temporary file not found.");
        }

        try
        {
            using (var package = new ExcelPackage(new FileInfo(tempFilePath)))
            {
                var worksheet = package.Workbook.Worksheets[0];
                var rowCount = worksheet.Dimension?.Rows ?? 0;

                var excelDataList = new List<ExcelData>();
                for (var row = 2; row <= rowCount; row++)
                {
                    var excelData = new ExcelData
                    {
                        Field1 = worksheet.Cells[row, 1].Text,
                        Field2 = worksheet.Cells[row, 2].Text,
                        Field3 = worksheet.Cells[row, 3].Text,
                        Field4 = worksheet.Cells[row, 4].Text,
                        Field5 = worksheet.Cells[row, 5].Text,
                        Field6 = worksheet.Cells[row, 6].Text,
                        Field7 = worksheet.Cells[row, 7].Text,
                        Field8 = worksheet.Cells[row, 8].Text,
                        Field9 = worksheet.Cells[row, 9].Text,
                        Field10 = worksheet.Cells[row, 10].Text,
                    };
                    excelDataList.Add(excelData);
                }

                await _context.ExcelData.AddRangeAsync(excelDataList);
                await _context.SaveChangesAsync();
            }
        }
        finally
        {
            // Delete the temporary file after processing
            System.IO.File.Delete(tempFilePath);
        }
    }
}