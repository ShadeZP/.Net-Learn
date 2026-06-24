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
            _logger.LogInformation("Handling GET request for Home/Index.");

            try
            {
                var sessionList = await _sessionRepository.ListAsync();

                var model = sessionList.Select(session => new StormSessionViewModel()
                {
                    Id = session.Id,
                    DateCreated = session.DateCreated,
                    Name = session.Name,
                    IdeaCount = session.Ideas.Count
                });

                _logger.LogDebug("Retrieved {Count} brainstorm sessions.", model.Count());

                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while loading brainstorm sessions.");
                return StatusCode(500);
            }
        }

        public class NewSessionModel
        {
            [Required]
            public string SessionName { get; set; }
        }

        [HttpPost]
        public async Task<IActionResult> Index(NewSessionModel model)
        {
            _logger.LogInformation("Handling POST request for Home/Index to create a new session: {SessionName}", model.SessionName);

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Model validation failed when creating session. ModelState: {@ModelState}", ModelState.Values);
                return BadRequest(ModelState);
            }
            else
            {
                try
                {
                    await _sessionRepository.AddAsync(new BrainstormSession()
                    {
                        DateCreated = DateTimeOffset.Now,
                        Name = model.SessionName
                    });

                    _logger.LogInformation("Brainstorm session '{SessionName}' created successfully.", model.SessionName);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Failed to create a new brainstorm session: {SessionName}", model.SessionName);
                    return StatusCode(500); // Internal Server Error
                }
            }

            return RedirectToAction(actionName: nameof(Index));
        }
    }
}
