using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BrainstormSessions.Core.Interfaces;
using BrainstormSessions.Core.Model;
using BrainstormSessions.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BrainstormSessions.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBrainstormSessionRepository _sessionRepository;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IBrainstormSessionRepository sessionRepository, ILogger<HomeController> logger)
        {
            _sessionRepository = sessionRepository;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var sessionList = await _sessionRepository.ListAsync();

            var model = sessionList.Select(session => new StormSessionViewModel()
            {
                Id = session.Id,
                DateCreated = session.DateCreated,
                Name = session.Name,
                IdeaCount = session.Ideas.Count
            });

            _logger.LogInformation($"Controller: {ControllerContext.ActionDescriptor.ControllerName}," +
                                    $" Action: {ControllerContext.ActionDescriptor.ActionName}," +
                                    $" Message: Visited");

            return View(model);
        }

        public class NewSessionModel
        {
            [Required]
            public string SessionName { get; set; }
        }

        [HttpPost]
        public async Task<IActionResult> Index(NewSessionModel model)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning($"Controller: {ControllerContext.ActionDescriptor.ControllerName}," +
                                    $" Action: {ControllerContext.ActionDescriptor.ActionName}," +
                                    $" Message: Model State is not valid:{model}");
                return BadRequest(ModelState);
            }
            else
            {
                await _sessionRepository.AddAsync(new BrainstormSession()
                {
                    DateCreated = DateTimeOffset.Now,
                    Name = model.SessionName
                });

                _logger.LogInformation($"Controller: {ControllerContext.ActionDescriptor.ControllerName}," +
                                    $" Action: {ControllerContext.ActionDescriptor.ActionName}," +
                                    $" Message: Created new Session");
            }

            return RedirectToAction(actionName: nameof(Index));
        }
    }
}
