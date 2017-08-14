using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Octokit;
using Octokit.Internal;

namespace CardsService.Model
{
    public class CardsRepository : ICardsRepository
    {
        private const int BacklogColumnId = 1364164;
        private const int ToDoColumnId = 1364165;
        private const int InProgressColumnId = 1364166;
        private const int DoneColumnId = 1364167;

        ProjectCardsClient _client;

        public CardsRepository()
        {
            ApiConnection connection = new ApiConnection(new Connection(new ProductHeaderValue("Test")));
            var token = new Credentials("");
            connection.Connection.Credentials = token;
            _client = new ProjectCardsClient(connection);
        }


        public IReadOnlyList<ProjectCard> GetBacklogCards()
        {
            var cards = _client.GetAll(BacklogColumnId).Result;

            return cards;
        }

        public IReadOnlyList<ProjectCard> GetToDoCards()
        {
            var cards = _client.GetAll(ToDoColumnId).Result;

            return cards;
        }

        public IReadOnlyList<ProjectCard> GetInProgressCards()
        {
            var cards = _client.GetAll(InProgressColumnId).Result;

            return cards;
        }

        public IReadOnlyList<ProjectCard> GetDoneCards()
        {
            var cards = _client.GetAll(DoneColumnId).Result;

            return cards;
        }
    }
}
