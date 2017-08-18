using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Octokit;
using CardsService.Model;

namespace CardsService.Controllers
{
    [Route("api/[controller]")]
    public class InProgressCardsController : Controller
    {
        ICardsRepository _repository;
        public InProgressCardsController(ICardsRepository repo)
        {
            _repository = repo;
        }

        [HttpGet]
        public IReadOnlyList<ProjectCard> Get()
        {
            return _repository.GetInProgressCards();
        }
    }
}
