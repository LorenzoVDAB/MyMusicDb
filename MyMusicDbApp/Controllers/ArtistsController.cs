using Microsoft.AspNetCore.Mvc;
using MyMusicDbServices; 

namespace MyMusicDbApp.Controllers;

public class ArtistsController : Controller {
    private readonly ArtistsService artistsService; 

    public ArtistsController(ArtistsService artistsService) {
        this.artistsService = artistsService; 
    }

    public IActionResult Index() {
        
        return View();
    }
}
