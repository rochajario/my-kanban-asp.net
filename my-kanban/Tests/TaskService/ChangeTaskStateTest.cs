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

            var resultEntity = new TaskEntity()
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
            };

            ClearDependencies();

            _taskRepositoryMock.Setup(x => x.Update(It.IsAny<TaskEntity>())).Verifiable();
            _taskRepositoryMock.Setup(x => x.GetWithParentItem(taskId)).Returns(resultEntity);

            var sut = GetSystemUnderTest();
            #endregion

            #region Act
            int boardId = sut.ChangeTaskState(taskId, taskState);
            #endregion

            #region Assert
            //Should return board's id
            Assert.True(boardId == resultEntity.Board.Id);
            _taskRepositoryMock.Verify(x => x.GetWithParentItem(taskId), Times.Once);
            _taskRepositoryMock.Verify(x => x.Update(It.IsAny<TaskEntity>()), Times.Once);
            #endregion
        }

        //TODO: Implement test that assert that no change is made in a task if the intended state is the actual state
    }
}
