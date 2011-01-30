using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using ReadModel;
using ReadModel.Model;
using ReadModel.Storage;
using Should.Fluent;

namespace Tests.ReadModel
{
    [TestFixture]
    public class KanbanBoardReadServiceTests
    {
        private IList<KanbanBoard> allBoards;

        [TestFixtureSetUp]
        public void Setup()
        {
            allBoards = new List<KanbanBoard>{
                    new KanbanBoard {Title = "Demo 1", User = "Marcus", TimesFavorited = 100, Posted = DateTime.Parse("2010-01-01")},
                    new KanbanBoard {Title = "Kanban 1", User = "David", TimesFavorited = 1000, Posted = DateTime.Parse("2010-04-01")},
                    new KanbanBoard {Title = "Demo 2", User = "Joakim", TimesFavorited = 300, Posted = DateTime.Parse("2010-06-01")},
                    new KanbanBoard {Title = "My new board", User = "Christophe", TimesFavorited = 50, Posted = DateTime.Parse("2011-01-01")}
                };
        }

        [Test]
        public void should_return_IndexViewModel_with_top_3_favorited_and_3_latest_additions()
        {
            // Arrange
            var mockRep = Substitute.For<IKanbanBoardRepository>();
            mockRep.GetAllKanbanBoards().Returns(allBoards);

            var readService = new KanbanBoardReadService(mockRep);

            // Act
            var viewModel = readService.GetIndexViewModel();

            // Assert
            viewModel.Should().Not.Be.Null();
            viewModel.LatestAddedKanbanBoards.Count.Should().Equal(3);
            viewModel.TopFavoritedKanbanBoards.Count.Should().Equal(3);

        }
    }
}
