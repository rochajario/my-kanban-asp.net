namespace Tests
{
    public abstract class BaseUnitTestM<T>
    {
        public abstract void ClearDependencies();
        public abstract T GetSystemUnderTest();
    }
}
