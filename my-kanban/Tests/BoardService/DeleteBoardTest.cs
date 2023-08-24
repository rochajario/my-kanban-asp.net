using Domain.Entities;
using Domain.Enums;
using Moq;
using Xunit;

namespace Tests.BoardService
{
    public class DeleteBoardTest : BoardServiceBaseTest
    {
        [Fact(DisplayName = "Given method call, then propagate database request")]
        public void ValidateDatabaseRequest()
        {
            #region Arrange
            int id = 1;
            var dummyEntity = new BoardEntity() { Id = id, Status = BoardState.Active };
            ClearDependencies();

            _repositoryMock
                .Setup(x => x.Get(id)).Returns(dummyEntity);
            _repositoryMock
                .Setup(x => x.Delete(id))
                .Verifiable();

            var sut = GetSystemUnderTest();
            #endregion

            #region Act
            sut.DeleteBoard(id);
            #endregion

            #region Assert
            _repositoryMock.Verify(x => x.Delete((int)dummyEntity.Id!), Times.Once);
            #endregion
        }

        [Fact(DisplayName = "Given inactive board, When trying to Delete, then raise Exception")]
        public void ValidateBoardStateBeforeDelete()
        {
            #region Arrange
            int id = 1;
            var dummyEntity = new BoardEntity() { Id = id, Status = BoardState.Inactive };
            ClearDependencies();

            _repositoryMock
                .Setup(x => x.Get(id))
                .Returns(dummyEntity);

            var sut = GetSystemUnderTest();
            #endregion

            #region Act
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => sut.DeleteBoard(id));
            #endregion

            #region Assert
            Assert.Contains("State Inactive", ex.Message);
            #endregion
        }
    }
}
