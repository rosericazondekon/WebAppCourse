using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCapp.Models;
public class Feedback
{
    public int Id { get; set;}
    [Required]
    public string userName { get; set; } = string.Empty;
    [StringLength(500)]
    public string userFeedback { get; set; } = string.Empty;
}