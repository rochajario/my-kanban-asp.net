using Domain.Entities;
using Domain.Enums;
using Moq;
using Xunit;

namespace Tests.BoardService
{
    public class GetBoardWithChildrenTasksTest : BoardServiceBaseTest
    {
        [Fact(DisplayName = "Given method call, Then return Board data with Task List")]
        public void CallFullRequestMethodOnDatabase()
        {
            #region Arrange
            BoardEntity entity = new ()
            {
                Id = 1,
                Status = BoardState.Active,
                UpdatedAt = DateTime.Now,
                Name = "Name",
                Description = "description",
                Tasks = new List<TaskEntity>()
                {
                    new TaskEntity() { Id = 1, Description = "description", Name =  "Name", UpdatedAt = DateTime.MinValue, Status = TaskState.Todo },
                    new TaskEntity() { Id = 2, Description = "description", Name =  "Name", UpdatedAt = DateTime.MinValue, Status = TaskState.Todo }
                }
            };
            ClearDependencies();

            _repositoryMock.Setup(x => x.GetWithChildrenItems(It.IsAny<int>())).Returns(entity);

            var sut = GetSystemUnderTest();
            #endregion

            #region Act
            sut.GetBoardWithChildrenTasks((int)entity.Id!);
            #endregion

            #region Assert
            _repositoryMock.Verify(x => x.GetWithChildrenItems((int)entity.Id!), Times.Once);
            #endregion
        }
    }
}
