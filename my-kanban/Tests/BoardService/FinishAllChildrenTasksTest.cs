
using Domain.Entities;
using Domain.Enums;
using Moq;
using Xunit;

namespace Tests.BoardService
{
    public class FinishAllChildrenTasksTest : BoardServiceBaseTest
    {
        [Fact(DisplayName = "Given method call, Then verify search call in Database")]
        public void ValidateCorrectChildrenIdentification()
        {
            #region Arrange
            BoardEntity board = GetDummyEntity();
            ClearDependencies();

            _repositoryMock
                .Setup(x => x.GetWithChildrenTasks((int)board.Id!))
                .Returns(board);
            _repositoryMock
                .Setup(x => x.Update(It.IsAny<BoardEntity>()))
                .Verifiable();

            var sut = GetSystemUnderTest();
            #endregion

            #region Act
            sut.FinishAllChildrenTasks((int)board.Id!);
            #endregion


            #region Assert
            _repositoryMock.Verify(x => x.GetWithChildrenTasks((int)board.Id!), Times.Once);
            #endregion
        }

        [Fact(DisplayName = "Given method call, Then verify update call in Database")]
        public void ValidateChildrenUpdate()
        {
            #region Arrange
            BoardEntity board = GetDummyEntity();
            ClearDependencies();

            _repositoryMock
                .Setup(x => x.GetWithChildrenTasks(1))
                .Returns(board);
            _repositoryMock
                .Setup(x => x.Update(It.IsAny<BoardEntity>()))
                .Verifiable();

            var sut = GetSystemUnderTest();
            #endregion

            #region Act
            sut.FinishAllChildrenTasks((int)board.Id!);
            #endregion


            #region Assert
            _repositoryMock.Verify(x => x.Update(It.Is<BoardEntity>(x => x.Tasks.All(x => x.Status == TaskState.Concluded))), Times.Once);
            #endregion
        }

        private BoardEntity GetDummyEntity()
        {
            return new()
            {
                Id = 1,
                UpdatedAt = DateTime.UtcNow,
                Status = BoardState.Active,
                Name = "Test",
                Description = "Test",
                Tasks = new List<TaskEntity>()
                {
                    new TaskEntity { Id = 1, UpdatedAt = DateTime.UtcNow, Status = TaskState.Todo },
                    new TaskEntity { Id = 2, UpdatedAt = DateTime.UtcNow, Status = TaskState.Doing },
                }
            };
        }
    }
}
