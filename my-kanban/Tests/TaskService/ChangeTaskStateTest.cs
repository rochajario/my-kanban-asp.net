using Domain.Entities;
using Domain.Enums;
using Moq;
using Xunit;

namespace Tests.TaskService
{
    public class ChangeTaskStateTest : TaskServiceBaseTest
    {
        [Fact(DisplayName = "Given state, When method are called, then update at database")]
        public void ChangeTaskState()
        {
            #region Arrange
            int taskId = 1;
            TaskState taskState = TaskState.Doing;

            ClearDependencies();

            _taskRepositoryMock.Setup(x => x.Update(It.IsAny<TaskEntity>())).Verifiable();
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
            sut.ChangeTaskState(taskId, taskState);
            #endregion

            #region Assert
            _taskRepositoryMock.Verify(x => x.GetWithParentItem(taskId), Times.Once);
            _taskRepositoryMock.Verify(x => x.Update(It.IsAny<TaskEntity>()), Times.Once);
            #endregion
        }
    }
}
