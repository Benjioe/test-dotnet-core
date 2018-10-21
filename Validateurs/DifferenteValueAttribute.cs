using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

public class DifferenteValueAttribute : ValidationAttribute, IClientModelValidator
{

    private string[] _PropertyWithDifferenteValue;

    public DifferenteValueAttribute(params string[] propertyWithDifferenteValue)
    {
        this._PropertyWithDifferenteValue = propertyWithDifferenteValue;
    }

    public void AddValidation(ClientModelValidationContext context)
    {
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        if(!context.Attributes.ContainsKey("data-val"))
            context.Attributes.Add("data-val", "true");
        context.Attributes.Add("data-val-different-value", "Vous ne pouvez pas renseigner deux fois la même valeur");     
        context.Attributes.Add("data-val-different-value-exclude", string.Join(",",_PropertyWithDifferenteValue.Select(x => $"[name={x}]")));
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var propertyList = validationContext.ObjectType.GetProperties().Where(x => _PropertyWithDifferenteValue.Contains(x.Name));
        var propertyValue = propertyList.Select(x => new { x.Name, Value= x.GetValue(validationContext.ObjectInstance)?.ToString()});  
        var sameValue = propertyValue.Where(x => x.Value == value.ToString());

        if(sameValue.Any())
        {
            string message = $"La valeur {value} est déjà utilisé par le(s) champ(s) {string.Join(",", sameValue.Select(x => x.Name)) }";
            return new ValidationResult(message);
        }

        return ValidationResult.Success;

    }
}
