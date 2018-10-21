using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using Microsoft.AspNetCore.Mvc;

public class IndexViewModel : INullable
{
    [Required]
    [Remote(action: "VerifiyIsTrucCool", controller: "Home")]
    [DifferenteValueAttribute("SecondTrucCool")]
    public string PremierTrucCool { get; set; }

    [Required]
    [Remote(action: "VerifiyIsTrucCool", controller: "Home")]
    [DifferenteValueAttribute("PremierTrucCool")]
    public string SecondTrucCool { get; set; }

    public bool IsNull => string.IsNullOrEmpty(PremierTrucCool) && string.IsNullOrEmpty(SecondTrucCool);
}