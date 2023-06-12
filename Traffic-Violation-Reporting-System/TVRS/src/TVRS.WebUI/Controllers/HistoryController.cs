using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TVRS.Application.DTOs.Responses;
using TVRS.Application.Services;
using TVRS.WebUI.Extensions;

namespace TVRS.WebUI.Controllers
{
    public class HistoryController : Controller
    {
        private readonly IReportService _reportService;
        public HistoryController(IReportService reportService)
        {
            _reportService = reportService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles ="User")]
        public async Task<IActionResult> ViewUserHistory() 
        {
            int userId = HttpContext.GetUserId();
            IEnumerable<DisplayViolationReportResponse> existingReports = await _reportService.GetViolationReportsByUserAsync(userId);

            return View(existingReports);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult ViewAllHistory()
        {
            return View();
        }
    }
}
