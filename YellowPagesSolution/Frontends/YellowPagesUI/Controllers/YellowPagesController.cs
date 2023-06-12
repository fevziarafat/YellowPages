using YellowPages.Shared.Dtos;
using YellowPagesUI.Business.Abstract;
using IEMailInformationService = YellowPagesUI.Business.Abstract.IEMailInformationService;

namespace YellowPagesUI.Controllers
{
    [Microsoft.AspNetCore.Authorization.AuthorizeAttribute]
    public class YellowPagesController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IEMailInformationService _eMailInformationService;
        private readonly IPhoneInformationService _phoneInformationService;
        private readonly ILocationInformationService _locationInformationService;
        private readonly IYellowPagesService _yellowPagesService;
        private readonly IReportService _reportService;

        private readonly YellowPages.Shared.Services.ISharedIdentityService _sharedIdentityService;

        public YellowPagesController(IEMailInformationService eMailInformationService, IPhoneInformationService phoneInformationService, ILocationInformationService locationInformationService, YellowPages.Shared.Services.ISharedIdentityService sharedIdentityService, IYellowPagesService yellowPagesService, IReportService reportService)
        {
            _eMailInformationService = eMailInformationService;
            _phoneInformationService = phoneInformationService;
            _locationInformationService = locationInformationService;
            _sharedIdentityService = sharedIdentityService;
            _yellowPagesService = yellowPagesService;
            _reportService = reportService;
        }
        public async Task<Microsoft.AspNetCore.Mvc.IActionResult> Index()
        {
            return View(await _yellowPagesService.GetAllContactAsync());

        }
        public async Task<Microsoft.AspNetCore.Mvc.IActionResult> Create()
        {
            var models = await _yellowPagesService.GetAllContactAsync();

            ViewBag.contactsList = models;

            return View();
        }

        [Microsoft.AspNetCore.Mvc.HttpPostAttribute]
        public async Task<Microsoft.AspNetCore.Mvc.IActionResult> Create(YellowPagesCreateDto contactCreateInput)
        {

            await _yellowPagesService.CreateAsync(contactCreateInput);

            return RedirectToAction(nameof(Index));
        }

        public async Task<Microsoft.AspNetCore.Mvc.IActionResult> AddEMail()
        {
            return  View();
        }

        [Microsoft.AspNetCore.Mvc.HttpPostAttribute]
        public async Task<Microsoft.AspNetCore.Mvc.IActionResult> AddEMail(string id, string email)
        {
          EMailInformationCreateDto model = new();
            model.ContactId = id;
            model.EMail = email;
            _eMailInformationService.CreateAsync(model);
            return RedirectToAction(nameof(Index));
        }
        public async Task<Microsoft.AspNetCore.Mvc.IActionResult> EmailDelete(string id)
        {
            var data = await _yellowPagesService.GetByIdAsync(id);
            ViewBag.email = data;
            return View();
        }
        public async Task<Microsoft.AspNetCore.Mvc.IActionResult> EmailDelete2(string id)
        {
            var result = await _eMailInformationService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }


        public async Task<Microsoft.AspNetCore.Mvc.IActionResult> AddPhone(string id)
        {
            return View();
        }
        [Microsoft.AspNetCore.Mvc.HttpPostAttribute]
        public async Task<Microsoft.AspNetCore.Mvc.IActionResult> AddPhone(string id, string phone)
        {

           PhoneInformationCreateDto model = new();
            model.ContactId = id;
            model.Phone = phone;
            _phoneInformationService.CreateAsync(model);
            return RedirectToAction(nameof(Index));
        }
        public async Task<Microsoft.AspNetCore.Mvc.IActionResult> PhoneDelete(string id)
        {
            var data = await _yellowPagesService.GetByIdAsync(id);

            ViewBag.phone = data;

            return View();
        }
        public async Task<Microsoft.AspNetCore.Mvc.IActionResult> PhoneDelete2(string id)
        {
            var result = await _phoneInformationService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }


        public async Task<Microsoft.AspNetCore.Mvc.IActionResult> AddLocation(string id)
        {
            return View();
        }

        [Microsoft.AspNetCore.Mvc.HttpPostAttribute]
        public async Task<Microsoft.AspNetCore.Mvc.IActionResult> AddLocation(string id, string location)
        {

            LocationInformationCreateDto model = new();
            model.ContactId = id;
            model.Location = location;
            _locationInformationService.CreateAsync(model);

            return RedirectToAction(nameof(Index));
        }
        public async Task<Microsoft.AspNetCore.Mvc.IActionResult> LocationDelete(string id)
        {
            var data = await _yellowPagesService.GetByIdAsync(id);

            ViewBag.location = data;

            return View();
        }
        public async Task<Microsoft.AspNetCore.Mvc.IActionResult> LocationDelete2(string id)
        {
            var result = await _locationInformationService.DeleteAsync(id);

            var k = result;
            return RedirectToAction(nameof(Index));
        }


        public async Task<Microsoft.AspNetCore.Mvc.IActionResult> Delete(string id)
        {
            await _yellowPagesService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }

        public async Task<Microsoft.AspNetCore.Mvc.IActionResult> AddReport(string id)
        {
            ViewBag.reports = await _reportService.GetAllReportAsync();

            return View(await _yellowPagesService.GetAllContactAsync());

        }

        

        public async Task<Microsoft.AspNetCore.Mvc.IActionResult> AddReport2(string location)
        {

            _yellowPagesService.AddReport(location);

          

            return RedirectToAction(nameof(Index));
        }

        public async Task<Microsoft.AspNetCore.Mvc.IActionResult> ReportDetails(string location)
        {

          var report= await _reportService.ReportById(location);

            return View(report);

            //return RedirectToAction(nameof(Index));
        }

    }
}
