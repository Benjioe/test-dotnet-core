# test-dotnet-core


De la configuration (nuGet, injection dépendances (jusque dans les vues @inject))
L'inclusion de projet open sources (Grunt, Gulp ...)
L'abandon de techologies (VB.NET, WebForm, edmx)

Features dotnet core

[Configurations]:
nuGet : Microsoft.Extensions.Configuration
// Ajout de la clé dans le provider 
provider = new MemoryConfigurationProvider(); 
provider.Add("uneCle", "uneValeur"); 
 
var config = new ConfigurationBuilder() 
                .Add(provider) 
                .Build(); 
 
// Récupération de la valeur 
string setting2 = config["uneCle"];


[Validateur]
public class MaxAmountAttribute : ValidationAttribute, IClientModelValidator 
{ 
    private int _maxAmount 
    public MaxAmountAttribute(int maxAmount) 
    { 
        this._maxAmount = maxAmount; 
    } 
 
    protected override ValidationResult IsValid(object value, 
ValidationContext validationContext) 
 
    { 
        Product product = validationContext.ObjectInstance as 
Product; 
 
        if(product.Type == "Encombrant" && (int)value > 
this._maxAmount) 
        { 
            return new ValidationResult( 
                 $"Ce nouveau produit encombrant est présent en 
trop grande quantité. Maximum : {this._maxAmount}"); 
        } 
 
        return ValidationResult.Success; 
    } 


    public IEnumerable<ModelClientValidationRule> 
GetClientValidationRules(ClientModelValidationContexte context) 
        { 
            yield return new ModelClientValidationRule("maxamount", 
                $"Ce nouveau produit encombrant est présent en 
trop grande quantité. Maximum : {this._maxAmount}"); 
        }
}

$(function () { 
    jQuery.validator.addMethod(’maxamount’, 
    function (value, element, params) { 
            // custom validation code 
        return false; 
    }, ’’); 
 
    jQuery.validator.unobtrusive.adapters.add(’maxamount’, 
    function (options) { 
        options.rules[’maxamount’] = {}; 
        options.messages[’maxamount’] = options.message; 
    }); 
}(jQuery));

 [Remote(action: "VerifyEmail", controller: "Users")]  => Validation a distance
Proprieté

  [AcceptVerbs("Get", "Post")] 
 public IActionResult VerifyEmail(string email) 
 { 
     if (!this.userRepo.VerifyEmail()) 
     { 
         return Json(data: string.Format("Email déjà 
utilisé.", email)); 
     } 
 
     return Json(data: true); 
 }


 [View Component]
 public class MyViewComponent: ViewComponent { 
 
 public MyViewComponent () { 
  //Initialisation de services si besoin 
 } 
 
 public async Task <IViewComponentResult> InvokeAsync( 
  string monParam) { 
   
  //Logique métier utilisant le paramètre 
  return View(monParam); 
 } 
}
@await Component.InvokeAsync("My", new { monParam = "param" })
 


[Test]
Créer un serveur pour ses tests automatiques
Nuget: Microsoft.AspNet.TestHost

private readonly TestServer _server; 
private readonly HttpClient _client; 
 
public MonTest() 
{ 
    // Arrange 
    _server = new TestServer(TestServer.CreateBuilder() 
        .UseStartup<Startup>()); 
 
    _client = _server.CreateClient(); 
} 
 
[Fact] 
public async Task ReturnHelloWorld() 
{ 
    // Act 
    var response = await _client.GetAsync("/"); 
    response.EnsureSuccessStatusCode(); 
 
    var responseString = await response.Content.ReadAsStringAsync(); 
 
    // Assert 
    Assert.Equal("Hello World!", responseString); 
}

[Formater]
// 1ère méthode 
services.AddMvc() 
        .AddXmlSerializerFormatters(); 
 
// 2ème méthode 
services.AddMvc(options => 
{ 
  options.OutputFormatters.Add(new XmlSerializerOutputFormatter()); 
});

[Produces("application/json")] 
public class MyControler

[Middelware]
    app.Use(async (context, next) => 
    { 
        logger.LogInformation("Premier appel"); 
        await next.Invoke(); 

        
        logger.LogInformation("Second appel"); 
    }); 
 

 [PAge d'erreur]
 app.UseStatusCodePagesWithRedirects("~/errors/{0}");


 [Elm]
          app.UseElmPage(); 
         app.UseElmCapture();
         => /elm


[composants html]

-------------------------------------------------------------------------------
var myCity = document.createElement(’my-city’); 
myCity.addEventListener(’click’, function(e) { 
  alert(’Thanks!’); 
});
-------------------------------------------------------------------------------
// Déclaration de l’élément 
var MyCity = document.registerElement(’my-city’, { 
  prototype: Object.create(HTMLElement.prototype, { 
    population: { 
      get: function() { return 5; } 
    }, 
    makeAlert: { 
      value: function() { 
        alert(’makeAlert() called’); 
      } 
    } 
  }) 
}); 
 
// Création de l’élément 
var xfoo = document.createElement(’x-foo’); 
 
// Ajout du nouvel élément sur la page 
document.body.appendChild(xfoo);
-------------------------------------------------------------------------------

var XFooProto = Object.create(HTMLElement.prototype); 
 
MyCityProto.createdCallback = function() { 
  // 1. Rattachement d’une racine DOM de type "shadow" à l’élément. 
  var shadow = this.createShadowRoot(); 
 
  // 2. Remplissage via du code HTML. 
  shadow.innerHTML = "<b>Je suis le Shadow DOM!</b>"; 
}; 
 
var MyCity = document.registerElement(’my-city-shadowdom’, 
{prototype: MyCityProto });


------------------------------------------------------------------------------------

<template id="mytemplate"> 
  <style> 
    p { color: red; } 
  </style> 
  <p>C’est le Shadow DOM, depuis un template !</p> 
</template> 
 
<script> 
var proto = Object.create(HTMLElement.prototype, { 
  createdCallback: { 
    value: function() { 
      var t = document.querySelector(’# mytemplate); 
      var clone = document.importNode(t.content, true); 
      this.createShadowRoot().appendChild(clone); 
    } 
  } 
}); 
document.registerElement(’x-element-from-template’, {prototype: 
proto}); 
</script>

<link rel="import" href="/chemin/du/fichier/stuff.html">    


[Route]
RouteBuilder().MapGet : Permet d'ajouter une méthode Get à partir d'u pattern d'url.
CHauqe élements de l'url peut se voir associé des contraintes ("action/param:contrainte").
On peut créer ses propres contraintes en implémetant IrouteConstraint


1) J'injecte le service
2 ?) Je l'ajoute à la configuration MVC
3) Je le configure
