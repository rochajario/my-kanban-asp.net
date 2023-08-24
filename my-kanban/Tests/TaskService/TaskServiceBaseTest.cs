using Moq;
using Repository.Interfaces;
using Service.Interfaces;
using Sut = Service.Services.TaskService;

namespace Tests.TaskService
{
    public class TaskServiceBaseTest : BaseUnitTest<ITaskService>
    {
        protected Mock<ITaskRepository> _taskRepositoryMock = new(MockBehavior.Strict);
        public override void ClearDependencies()
        {
            _taskRepositoryMock.Reset();
        }

        public override ITaskService GetSystemUnderTest()
        {
            return new Sut(_taskRepositoryMock.Object);
        }
    }
}
