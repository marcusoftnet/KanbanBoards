using CommandService;
using CommandService.Commands;
using Domain;
using NSubstitute;
using NUnit.Framework;
using Repositories.Storage;

namespace Tests.WriteService
{
    [TestFixture]
    public class KanbanBoardCommandServiceTests
    {

        [Test]
        public void should_add_a_KanbanBoard_when_called_with_correct_AddKanbanBoardCommand()
        {
            // Arrange
            var cmd = new AddKanbanBoardCommand {
                              Title = "Test tile", User = "Marcus",
                              Description = "A long description that contains information",
                              BoardImage = @"C:\Path\", Tags = "Tag1, Tag2, Tag3"
                          };

            var repository = Substitute.For<IKanbanBoardRepository>();
            var commandService = new KanbanBoardCommandService(repository);

            // Act
            commandService.AddKanbanBoard(cmd);

            // Assert
            repository.Received().Add(Arg.Is<KanbanBoard>(x => x.Title == cmd.Title));
            repository.Received().Add(Arg.Is<KanbanBoard>(x => x.User == cmd.User));
            repository.Received().Add(Arg.Is<KanbanBoard>(x => x.Tags == cmd.Tags));
            repository.Received().Add(Arg.Is<KanbanBoard>(x => x.Description == cmd.Description));
        }
    }
}
