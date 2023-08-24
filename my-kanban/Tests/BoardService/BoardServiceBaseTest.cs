using Moq;
using Repository.Interfaces;
using Service.Interfaces;
using Sut = Service.Services.BoardService;

namespace Tests.BoardService
{
    public class BoardServiceBaseTest : BaseUnitTestM<IBoardService>
    {
        protected Mock<IBoardRepository> _repositoryMock = new(MockBehavior.Strict);
        public override void ClearDependencies()
        {
            _repositoryMock = new(MockBehavior.Strict);
        }

        public override IBoardService GetSystemUnderTest()
        {
            return new Sut(_repositoryMock.Object);
        }
    }
}
