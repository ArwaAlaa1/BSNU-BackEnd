using AutoMapper;
using BSNU.Core;
using BSNU.Core.Models;
using BSNU.Core.Repository.Contract;
using BSNUDashboard.Helper;
using BSNUDashboard.ViewsModels;
using Microsoft.AspNetCore.Mvc;

namespace BSNUDashboard.Controllers
{
    public class BannerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;
        private readonly IBannerRepository _bannerRepository;

        public BannerController(IUnitOfWork unitOfWork, IMapper mapper
            , IWebHostEnvironment webHostEnvironment, IBannerRepository bannerRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _environment = webHostEnvironment;
            _bannerRepository = bannerRepository;
        }

       
        public async Task<IActionResult> Index(bool? statusFilter, int page = 1, int pageSize = 5)
        {
            try
            {
                var banners = await _bannerRepository.GetBannerswithStatusAsync(page, pageSize, statusFilter);
                ViewBag.StatusFilter = statusFilter;

                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return PartialView("_BannerTablePartial", banners);
                }

                return View(banners);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }


        public async Task<IActionResult> Details(int id)
        {
            var banner = await _unitOfWork.Repository<Banner>().GetByIdAsync(id);

            return View(banner);
        }


     
        public async Task<IActionResult> AddBanner()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddBanner(BannerVM bannerVM)
        {
            if (!ModelState.IsValid)
            {
                return View(bannerVM);
            }

            try
            {



                if (bannerVM.Photo != null)
                {
                    bannerVM.ImageUrl =  HandlerPhotos.UploadPhoto(bannerVM.Photo,"Banners");
                }

                var banner = _mapper.Map<Banner>(bannerVM);
                _unitOfWork.Repository<Banner>().AddAsync(banner);
                await _unitOfWork.CompleteAsync();

                TempData["SuccessMessage"] = "AddBannerSuccessfully";
                return RedirectToAction("Index", "Banner");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.InnerException?.Message ?? ex.Message);
                return View(bannerVM);
            }
        }



       
        public async Task<IActionResult> Edit(int id)
        {
            var banner = await _unitOfWork.Repository<Banner>().GetByIdAsync(id);
            var mappedbanner = _mapper.Map<BannerVM>(banner);
            return View(mappedbanner);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BannerVM bannerVM)
        {
            try
            {
                var banner = await _unitOfWork.Repository<Banner>().GetByIdAsync(bannerVM.Id.Value);

                if (bannerVM.Photo != null)
                {
                    if (!string.IsNullOrEmpty(banner.ImageUrl))
                    {
                        HandlerPhotos.DeletePhoto(banner.ImageUrl, "Banners");
                    }

                    bannerVM.ImageUrl = HandlerPhotos.UploadPhoto(bannerVM.Photo, "Banners");
                }
               
                bannerVM.ImageUrl = banner.ImageUrl;
                _mapper.Map(bannerVM, banner);

                _unitOfWork.Repository<Banner>().Update(banner);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.InnerException?.Message ?? ex.Message);
            }



            return View(bannerVM);
        }





        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleActive(int id, bool isActive)
        {
            var banner = await _unitOfWork.Repository<Banner>().GetByIdAsync(id);
            if (banner == null) return NotFound();

            banner.IsActive = isActive;
            await _unitOfWork.CompleteAsync();

            return Ok();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var banner = await _unitOfWork.Repository<Banner>().GetByIdAsync(id);
            if (banner == null)
                return NotFound();
            banner.IsDeleted = true;

            _unitOfWork.Repository<Banner>().Update(banner);
            await _unitOfWork.CompleteAsync();

            return Ok();
        }


    }
}
