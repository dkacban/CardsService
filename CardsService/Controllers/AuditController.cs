using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CardsService.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CardsService.Controllers
{
    [Route("api/[controller]")]
    public class AuditController : Controller
    {
        IAuditRepository _repository;

        public AuditController(IAuditRepository repo)
        {
            _repository = repo;
        }

        [HttpGet]
        public IEnumerable<Audit> Get(int id)
        {
            return _repository.GetByCardId(id);
        }
    }
}
