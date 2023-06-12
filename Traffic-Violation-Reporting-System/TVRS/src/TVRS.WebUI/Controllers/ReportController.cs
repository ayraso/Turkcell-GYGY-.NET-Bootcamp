using Microsoft.AspNetCore.Mvc;
using System.Composition;
using TVRS.Application.Services.Option_Service;
using TVRS.Application.Services;
using TVRS.Domain.Entities;
using TVRS.WebUI.Models;
using System.Security.Claims;
using TVRS.Application.DTOs.Requests;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using TVRS.WebUI.Extensions;

namespace TVRS.WebUI.Controllers
{
    public class ReportController : Controller
    {
        private readonly IOptionService _optionService;
        private readonly IReportService _reportService;

        public ReportController(IOptionService optionService, IReportService reportService)
        {
            _optionService = optionService;
            _reportService = reportService;
        }

        [Authorize(Roles ="User")]
        public async Task<IActionResult> Create()
        {
            var subtopics = await _optionService.GetAllSubtopicsAsync();
            var districts = await  _optionService.GetAllDistrictsAsync();

            var model = new ReportCreatingModel
            {
                Subtopics = subtopics,
                Districts = districts
            };

            return View(model);
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public IActionResult CreateNewReport(NewViolationReportRequest newReport)
        {
            if (ModelState.IsValid)
            {
                newReport.UserId = HttpContext.GetUserId();
                newReport.ReportDate = DateTime.Now;
                _reportService.CreateNewViolationReport(newReport);
                return RedirectToAction("ViewUserHistory", "History"); 
            }
            return View();
        }

        [Authorize(Roles = "User, Admin")]
        public ActionResult ReportDetails(int reportId)
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ChangeReportStatus(int reportId, string newStatus)
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult DeleteReport(int reportId)
        {
            return View();
        }
    }
}
