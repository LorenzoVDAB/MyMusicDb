using Microsoft.AspNetCore.Mvc;
using MyMusicDbServices;
using MyMusicDbServices.DTOs;
using MyMusicDbApp.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MyMusicDbApp.Controllers;

public class ArtistsController : Controller {
    private readonly ArtistsService artistsService; 

    public ArtistsController(ArtistsService artistsService) {
        this.artistsService = artistsService; 
    }

    public async Task<IActionResult> Index() {
        //Get the artistDTOs from the artistsService (use pagination to not show all of them - to be implemented) 
        List<ArtistDTO>? artistDTOs = await artistsService.GetAllAsync(0, 30);
        List<ArtistViewModel> artistViewModels = new(); 

        if (artistDTOs != null) {
            //For each artistDTO in the artistDTOs list, create a new ArtistViewModel 
            artistViewModels = artistDTOs.Select(a => new ArtistViewModel() {
                Id = a.Id,
                Name = a.Name,
                DateOfBirth = a.DateOfBirth,
                Country = a.Country,
            }).ToList();
        }

        return View(artistViewModels);
    }

    [HttpGet]
    public IActionResult Create() {
        //default values
        ArtistCreateViewModel artist = new() { 
            DateOfBirth = DateTime.Now,
        };

        return View(artist);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ArtistCreateViewModel viewmodel) {
        if (!ModelState.IsValid) {
            return View(viewmodel); 
        }

        await artistsService.AddAsync(new ArtistDTO() {
            Name = !String.IsNullOrEmpty(viewmodel.Name) ? viewmodel.Name : null,
            Country = !String.IsNullOrEmpty(viewmodel.Country) ? viewmodel.Country : null,
            DateOfBirth = viewmodel.DateOfBirthKnown ? viewmodel.DateOfBirth : null
        });
        return RedirectToAction(nameof(Index)); 
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id) {
        ArtistDTO? artistDTO = await artistsService.GetByIdAsync(id);
        ArtistViewModel? artistViewmodel;

        if (artistDTO == null) {
            artistViewmodel = null; 
        } else {
            artistViewmodel = new() {
                Id = id,
                Name = artistDTO.Name,
                Country = artistDTO.Country,
                DateOfBirth = artistDTO.DateOfBirth
            };
        }

        return View(artistViewmodel);
    }

    [HttpPost]
    public async Task<IActionResult> Destroy(int id) {
        await artistsService.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id) {
        ArtistDTO? artistDTO = await artistsService.GetByIdAsync(id);
        ArtistEditViewModel? artistViewmodel;

        if (artistDTO == null) {
            artistViewmodel = null;
        } else {
            artistViewmodel = new() {
                Id = id,
                Name = artistDTO.Name,
                Country = artistDTO.Country,
                DateOfBirth = artistDTO.DateOfBirth,
                DateOfBirthKnown = (artistDTO.DateOfBirth != null)
            };
        }

        return View(artistViewmodel);
    }

    [HttpPost]
    public async Task<IActionResult> Update(ArtistEditViewModel viewmodel) {
        if (!ModelState.IsValid) {
            return View(nameof(Edit), viewmodel);
        }

        ArtistDTO? artistDTO = await artistsService.GetByIdAsync(viewmodel.Id); 

        if (artistDTO != null) {
            artistDTO.Name = viewmodel.Name;
            artistDTO.Country = viewmodel.Country;
            artistDTO.DateOfBirth = viewmodel.DateOfBirth;

            await artistsService.UpdateAsync(artistDTO);
        }

        return RedirectToAction(nameof(Index));
    }
}
