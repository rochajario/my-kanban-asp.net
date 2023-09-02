using Domain.Entities;
using Domain.Enums;
using Moq;
using Xunit;

namespace Tests.TaskService
{
    public class GetTaskWithParentBoardTest : TaskServiceBaseTest
    {
        [Fact (DisplayName="Given Method Call, Then Validate Repository Request")]
        public void GetTaskWithParentBoard()
        {
            #region Arrange
            int taskId = 1;
            ClearDependencies();

            _taskRepositoryMock.Setup(x => x.GetWithParentItem(taskId)).Returns(new TaskEntity()
            {
                Id = taskId,
                Board = new BoardEntity()
                {
                    Id = 123,
                    Status = BoardState.Active,
                    Name = "Test",
                    Description = "Test",
                },
                Name = "Test",
                Description = "Test",
                Status = TaskState.Todo
            });

            var sut = GetSystemUnderTest();
            #endregion

            #region Act
            TaskEntity result = sut.GetTaskWithParentBoard(taskId);
            #endregion

            #region Assert
            _taskRepositoryMock.Verify(x => x.GetWithParentItem(taskId), Times.Once);
            #endregion
        }
    }
}
