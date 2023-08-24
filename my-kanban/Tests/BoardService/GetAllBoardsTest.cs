using Domain.Entities;
using Moq;
using Xunit;

namespace Tests.BoardService
{
    public class GetAllBoardsTest : BoardServiceBaseTest
    {
        [Fact(DisplayName = "Given method call, Then validate database request")]
        public void ValidateDatabaseRequest()
        {
            #region Arrange
            ClearDependencies();

            _repositoryMock
                .Setup(x => x.GetAll())
                .Returns(new List<BoardEntity>());

            var sut = GetSystemUnderTest();
            #endregion

            #region Act
            IEnumerable<BoardEntity> result = sut.GetAllBoards();
            #endregion

            #region Assert
            _repositoryMock.Verify(x => x.GetAll(), Times.Once);
            #endregion
        }
    }
}
