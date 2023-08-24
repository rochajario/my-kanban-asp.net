using Domain.Dtos;
using Domain.Entities;
using Moq;
using Service.Interfaces;
using Xunit;

namespace Tests.BoardService
{
    public class CreateBoardTest : BoardServiceBaseTest
    {
        [Fact(DisplayName = "Given board creation, When method is called, Then verify if database is requested")]
        public void ValidateDatabaseCall()
        {
            #region Arrange
            ClearDependencies();

            _repositoryMock
                .Setup(x => x.Create(It.IsAny<BoardEntity>()))
                .Verifiable();

            IBoardService sut = GetSystemUnderTest();
            #endregion

            #region Act
            sut.CreateBoard(new BoardDto { Name = "Test", Description = "Test" });
            #endregion

            #region Assert
            _repositoryMock.Verify(x => x.Create(It.IsAny<BoardEntity>()), Times.Once);
            #endregion
        }
    }
}
