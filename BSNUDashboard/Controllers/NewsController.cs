using AutoMapper;
using BSNU.Core;
using BSNU.Core.Models;
using BSNU.Repository;
using BSNUDashboard.Helper;
using BSNUDashboard.ViewsModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BSNUDashboard.Controllers
{
    public class NewsController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<StaffMember> _userManager;
        private readonly IMapper _mapper;

        public NewsController(IUnitOfWork unitOfWork, UserManager<StaffMember> userManager,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
           _mapper = mapper;
        }
        
        public async Task<ActionResult> Index()
        {
            var news =await _unitOfWork.Repository<News>().GetAllAsync();

            return View(news);
        }

      
        public ActionResult Details(int id)
        {
            return View();
        }


        //public async Task<ActionResult> Create()
        //{
        //    var categories = await _unitOfWork.Repository<Category>().GetAllAsync();
        //    var programs = await _unitOfWork.Repository<ProgramEntite>().GetAllAsync();

        //    var model = new NewsVM
        //    {
        //        Categories = categories.Select(c => new SelectListItem
        //        {
        //            Value = c.Id.ToString(),
        //            Text = c.Name
        //        }),
        //        Programs = programs.Select(p => new SelectListItem
        //        {
        //            Value = p.Id.ToString(),
        //            Text = p.Name
        //        })
        //    };

        //    return View(model);
        //}


        //[Authorize]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(NewsVM model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        // إعادة تحميل الـ dropdowns في حالة الخطأ
        //        model.Categories = (await _unitOfWork.Repository<Category>().GetAllAsync())
        //            .Select(c => new SelectListItem
        //            {
        //                Value = c.Id.ToString(),
        //                Text = c.Name
        //            });

        //        model.Programs = (await _unitOfWork.Repository<ProgramEntite>().GetAllAsync())
        //            .Select(p => new SelectListItem
        //            {
        //                Value = p.Id.ToString(),
        //                Text = p.Name
        //            });

        //        return View(model);
        //    }

        //    if (model.ImageFile != null)
        //    {
        //        model.Image = HandlerPhotos.UploadPhoto(model.ImageFile, "News");
        //    }

        //    var news = _mapper.Map<News>(model);

        //    await  _unitOfWork.Repository<News>().AddAsync(news);
        //    await _unitOfWork.CompleteAsync();

        //    return RedirectToAction(nameof(Index));
        //}


        // GET: NewsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NewsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NewsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NewsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
