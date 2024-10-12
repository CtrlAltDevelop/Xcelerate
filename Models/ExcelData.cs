using System.ComponentModel.DataAnnotations;

namespace Xcelerate.Models;

public class ExcelData
{
    [Key]
    public int Id { get; set; }  // Primary key with auto-increment

    [Required]
    public required string Field1 { get; set; }
    [Required]
    public required string Field2 { get; set; }
    [Required]
    public required string Field3 { get; set; }
    [Required]
    public required string Field4 { get; set; }
    [Required]
    public required string Field5 { get; set; }
    [Required]
    public required string Field6 { get; set; }
    [Required]
    public required string Field7 { get; set; }
    [Required]
    public required string Field8 { get; set; }
    [Required]
    public required string Field9 { get; set; }
    [Required]
    public required string Field10 { get; set; }
}
