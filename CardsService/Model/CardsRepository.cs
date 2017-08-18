using System.Collections.Generic;
using Octokit;
using System;
using System.Threading.Tasks;

namespace CardsService.Model
{
    public class CardsRepository : ICardsRepository
    {
        public const int BacklogColumnId = 1364164;
        public const int ToDoColumnId = 1364165;
        public const int InProgressColumnId = 1364166;
        public const int DoneColumnId = 1364168;
        private const string GithubToken = "";

        ProjectCardsClient _client;
        ProjectsClient _projectsClient;

        public CardsRepository()
        {
            ApiConnection connection = new ApiConnection(new Connection(new ProductHeaderValue("Test")));
            var token = new Credentials(GithubToken);
            connection.Connection.Credentials = token;
            _client = new ProjectCardsClient(connection);
            _projectsClient = new ProjectsClient(connection);
        }

        public bool ArePreRequirementsMet(string projectName)
        {
            var result = false;
            var projectExist = false;

            try
            {
                var projects = _projectsClient.GetAllForRepository("dkacban", projectName).Result.Count;
                if(projects>0)
                {
                    projectExist = true;
                }
            }
            catch
            {
                return false;
            }

            result = _projectsClient.Column.Get(BacklogColumnId).Result != null
                && _projectsClient.Column.Get(ToDoColumnId).Result != null
                && _projectsClient.Column.Get(InProgressColumnId).Result != null
                && _projectsClient.Column.Get(DoneColumnId).Result != null
                && projectExist;

            return result;
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

        public async Task ReplaceText(string from, string to, int columnId)
        {
            var cards = _client.GetAll(columnId).Result;
            foreach(var card in cards)
            {
                var note = card.Note;
                if (card.Note.Contains(from))
                {
                    var update = new ProjectCardUpdate(note.Replace(from, to));
                    await _client.Update(card.Id, update);
                }
            }
        }
    }
}
