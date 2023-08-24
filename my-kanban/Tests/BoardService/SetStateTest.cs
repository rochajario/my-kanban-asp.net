﻿using Domain.Entities;
using Domain.Enums;
using Moq;
using Xunit;

namespace Tests.BoardService
{
    public class SetStateTest : BoardServiceBaseTest
    {
        [Fact (DisplayName = "Given Active Board, When set board to inactive, then verify dabase update")]
        public void SwitchBoardState()
        {
            #region Arrange
            ClearDependencies();

            _repositoryMock
                .Setup(x => x.Get(It.IsAny<int>()))
                .Returns(new BoardEntity { Id = 1, Status = BoardState.Active });
            _repositoryMock
                .Setup(x => x.Update(It.IsAny<BoardEntity>()))
                .Verifiable();

            var sut = GetSystemUnderTest();
            #endregion

            #region Act
            sut.SetBoardState(1, BoardState.Inactive);
            #endregion

            #region Assert
            _repositoryMock.Verify(x => x.Update(It.Is<BoardEntity>(x => x.Status == BoardState.Inactive)), Times.Once);
            #endregion
        }
    }
}
