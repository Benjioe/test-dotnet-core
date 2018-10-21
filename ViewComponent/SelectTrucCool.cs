using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace test_dotnet_core
{

[ViewComponent]
public class SelectTrucCool : ViewComponent {
    private Dictionary<string, string> _trucCoolToView;

    public SelectTrucCool(IConfiguration configuration)
    {
            var sectionCOnfiguration = configuration.GetSection("TrucCools");
            _trucCoolToView = sectionCOnfiguration.Get<Dictionary<string, string>>();
        
    }

    public async Task<IViewComponentResult> InvokeAsync(string nameTrucCool)
    {
        var nameView = $"../../{_trucCoolToView[nameTrucCool]}";
        return View(nameView);
    }
}
}
