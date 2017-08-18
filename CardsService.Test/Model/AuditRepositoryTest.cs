using System;
using System.Collections.Generic;
using System.Text;
using CardsService.Model;
using Xunit;

namespace CardsService.Test.Model
{
    public class AuditRepositoryTest
    {
        [Fact]
        public void ShouldAddAuditRedordToDatabase()
        {
            var repo = new AuditRepository();
            var count1 = repo.GetAll().Count;
            repo.Add("details");
            var count2 = repo.GetAll().Count;
            Assert.True(count2 == count1 + 1);
        }
    }
}
