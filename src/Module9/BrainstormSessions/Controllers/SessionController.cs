﻿using System.Threading.Tasks;
using BrainstormSessions.Core.Interfaces;
using BrainstormSessions.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BrainstormSessions.Controllers
{
    public class SessionController : Controller
    {
        private readonly IBrainstormSessionRepository _sessionRepository;
        private readonly ILogger<SessionController> _logger;

        public SessionController(IBrainstormSessionRepository sessionRepository, ILogger<SessionController> logger)
        {
            _sessionRepository = sessionRepository;
            _logger = logger;
        }

        public async Task<IActionResult> Index(int? id)
        {
            if (!id.HasValue)
            {
                _logger.LogWarning($"Controller: {ControllerContext.ActionDescriptor.ControllerName}," +
                                    $" Action: {ControllerContext.ActionDescriptor.ActionName}," +
                                    $" Message: ID has no value: {id}");

                return RedirectToAction(actionName: nameof(Index),
                    controllerName: "Home");
            }

            var session = await _sessionRepository.GetByIdAsync(id.Value);
            if (session == null)
            {
                _logger.LogWarning($"Controller: {ControllerContext.ActionDescriptor.ControllerName}," +
                                    $" Action: {ControllerContext.ActionDescriptor.ActionName}," +
                                    $" Message: Session not found: {session}");

                return Content("Session not found.");
            }

            var viewModel = new StormSessionViewModel()
            {
                DateCreated = session.DateCreated,
                Name = session.Name,
                Id = session.Id
            };

            _logger.LogInformation($"Controller: {ControllerContext.ActionDescriptor.ControllerName}," +
                                   $" Action: {ControllerContext.ActionDescriptor.ActionName}," +
                                   $" Message: Visited");

            return View(viewModel);
        }
    }
}
