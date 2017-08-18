using System.Collections.Generic;
using Octokit;

namespace CardsService.Model
{
    public class CardsRepository : ICardsRepository
    {
        private const int BacklogColumnId = 1364164;
        private const int ToDoColumnId = 1364165;
        private const int InProgressColumnId = 1364166;
        private const int DoneColumnId = 1364168;
        private const string GithubToken = "";

        ProjectCardsClient _client;

        public CardsRepository()
        {
            ApiConnection connection = new ApiConnection(new Connection(new ProductHeaderValue("Test")));
            var token = new Credentials(GithubToken);
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
