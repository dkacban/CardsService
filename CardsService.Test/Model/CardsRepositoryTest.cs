using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using CardsService.Model;

namespace CardsService.Test.Model
{
    public class CardsRepositoryTest
    {
        [Fact]
        public void ShouldGetReadAllCardsFromGithubProject()
        {
            var repo = new CardsRepository();
        }
    }
}
