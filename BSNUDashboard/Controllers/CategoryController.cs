using AutoMapper;
using BSNU.Core;
using BSNU.Core.Models;
using BSNU.Core.Repository.Contract;
using BSNUDashboard.Helper;
using BSNUDashboard.ViewsModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq.Expressions;

public class CategoryController : Controller
{

    private readonly ICategoryRepository _catRepo;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CategoryController(ICategoryRepository catRepo,IMapper mapper,IUnitOfWork unitOfWork)
    {
        
        _catRepo = catRepo;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index(
        int page = 1,
        int pageSize = 5,
        string search = null)
    {
        Expression<Func<Category, bool>> filter = null;

        if (!string.IsNullOrWhiteSpace(search))
            filter = c => c.Name.Contains(search);

        var result = await _catRepo.GetFilteredAsync(filter, page, pageSize);
      
        ViewBag.Search = search;
      
        return View(result);
    }


    public async Task<IActionResult> Details(int id)
    {
        var category = await _catRepo.GetByIdAsync(id);
        if (category == null)
            return NotFound();

        return View(category);
    }


    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CategoryVM model)
    {
      
        if (ModelState.IsValid)
        {
            var imageName = "";
            if (model.ImageFile != null)
            {
                imageName = HandlerPhotos.UploadPhoto(model.ImageFile, "Category");
            }
           
            model.Image = imageName;
            var mappedCat = _mapper.Map<Category>(model);
            await _catRepo.AddAsync(mappedCat);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(model);
      
    }

    
}
