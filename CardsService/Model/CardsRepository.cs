using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Octokit;

namespace CardsService.Model
{
    public class CardsRepository : ICardsRepository
    {
        public IList<Card> GetAllCards()
        {
            var client = new GitHubClient(new ProductHeaderValue("MyAmazingApp"));
            var user = client.Repository.Get(123);


            return null;
        }
    }
}
