using BSNU.Core.Models;
using BSNU.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BSNU.Repository;
using BSNUDashboard.ViewsModels;
using BSNUDashboard.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace BSNUDashboard.Controllers
{
    public class NewsController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;

        public NewsController(IUnitOfWork unitOfWork, UserManager<AppUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
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

        
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(NewsVM newsVM)
        {
            try
            {
                
                var userName = User.Identity.Name; // from [Authorize]
                var user = await _userManager.Users
                                             .Include(u => u.Program) // include Program
                                             .FirstOrDefaultAsync(u => u.UserName == userName);

                if (ModelState.IsValid)
                {
                    var imageName = "";
                    if (newsVM.Image != null)
                    {
                        imageName = HandlerPhotos.UploadPhoto(newsVM.Image, "News");
                    }
                    var AddedNew = new News
                    {
                        Title = newsVM.Title,
                        Description = newsVM.Description,
                        ImageUrl = imageName,
                        ProgramId = user.Program.Id

                    };
               
                    await _unitOfWork.Repository<News>().AddAsync(AddedNew) ;
                    await _unitOfWork.SaveAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(newsVM);
            }
        }

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
