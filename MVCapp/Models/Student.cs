using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCapp.Models;
public class Student
{
    [Required]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; } = string.Empty;

    [DataType(DataType.Date)]
    public DateTime DOB { get; set; }

    [Range(0, 99999.99)]
    public decimal Tuition { get; set; }

    [StringLength(50)]
    public string Notes { get; set; } = string.Empty;
}