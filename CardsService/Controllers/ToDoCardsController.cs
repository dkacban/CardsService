using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Octokit;
using CardsService.Model;

namespace CardsService.Controllers
{
    [Route("api/[controller]")]
    public class ToDoCardsController : Controller
    {
        ICardsRepository _repository;
        public ToDoCardsController(ICardsRepository repo)
        {
            _repository = repo;
        }

        [HttpGet]
        public IReadOnlyList<ProjectCard> Get()
        {
            return _repository.GetToDoCards();
        }
    }
}
