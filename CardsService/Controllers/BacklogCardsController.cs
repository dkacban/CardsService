using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CardsService.Model;
using Octokit;

namespace CardsService.Controllers
{
    [Route("api/[controller]")]
    public class BacklogCardsController : Controller
    {
        ICardsRepository _repository;
        IAuditRepository _audit;

        public BacklogCardsController(ICardsRepository repository, IAuditRepository audit)
        {
            _repository = repository;
            _audit = audit;
        }

        [HttpGet]
        public IReadOnlyList<ProjectCard> Get()
        {
            _audit.Add("Get all cards");
            return _repository.GetBacklogCards();
        }

        [HttpGet("{id}")]
        public ProjectCard Get(int id)
        {
            _audit.Add($"Get single card: {id}");
            return null;
        }

        [HttpPost]
        public void Post([FromBody]ProjectCard value)
        {
            _audit.Add($"Insert single card: {value.Id}");
        }

        [HttpPut]
        public void Put(int id, string from, string to)
        {
            _audit.Add($"Update card", id);
            _repository.ReplaceText(from, to, id);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _audit.Add($"Delete single card: {id}");
        }
    }
}