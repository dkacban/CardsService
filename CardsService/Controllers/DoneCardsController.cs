using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Octokit;
using CardsService.Model;

namespace CardsService.Controllers
{
    [Route("api/[controller]")]
    public class DoneCardsController : Controller
    {
        ICardsRepository _repository;
        public DoneCardsController(ICardsRepository repo)
        {
            _repository = repo;
        }

        [HttpGet]
        public IReadOnlyList<ProjectCard> Get()
        {
            return _repository.GetDoneCards();
        }
    }
}
