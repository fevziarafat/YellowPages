namespace YellowPagesUI.Controllers
{
    [Microsoft.AspNetCore.Authorization.AuthorizeAttribute]
    public class YellowPagesController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly YellowPagesUI.Services.IEMailInformationService _eMailInformationService;
        private readonly YellowPagesUI.Services.IPhoneInformationService _phoneInformationService;
        private readonly YellowPagesUI.Services.ILocationInformationService _locationInformationService;
        private readonly YellowPagesUI.Services.IYellowPagesService _yellowPagesService;
        private readonly YellowPagesUI.Services.IReportService _reportService;

        private readonly YellowPages.Shared.Services.ISharedIdentityService _sharedIdentityService;

        public YellowPagesController(YellowPagesUI.Services.IEMailInformationService eMailInformationService, YellowPagesUI.Services.IPhoneInformationService phoneInformationService, YellowPagesUI.Services.ILocationInformationService locationInformationService, YellowPages.Shared.Services.ISharedIdentityService sharedIdentityService, YellowPagesUI.Services.IYellowPagesService yellowPagesService, YellowPagesUI.Services.IReportService reportService)
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
            var contacts = await _yellowPagesService.GetAllContactAsync();

            ViewBag.contactsList = contacts;

            return View();
        }

        [Microsoft.AspNetCore.Mvc.HttpPostAttribute]
        public async Task<Microsoft.AspNetCore.Mvc.IActionResult> Create(YellowPagesUI.Models.YellowPages.YellowPagesCreateDto contactCreateInput)
        {

            await _yellowPagesService.CreateAsync(contactCreateInput);

            return RedirectToAction(nameof(Index));
        }

        public async Task<Microsoft.AspNetCore.Mvc.IActionResult> AddEMail()
        {
            return View();
        }

        [Microsoft.AspNetCore.Mvc.HttpPostAttribute]
        public async Task<Microsoft.AspNetCore.Mvc.IActionResult> AddEMail(string id, string email)
        {
           YellowPagesUI.Models.EMailInformations.EMailInformationCreateDto model = new();
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

            YellowPagesUI.Models.PhoneInformation.PhoneInformationCreateDto model = new();
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

            YellowPagesUI.Models.LocationInformation.LocationInformationCreateDto model = new();
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
