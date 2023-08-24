namespace Tests
{
    public abstract class BaseUnitTest<T>
    {
        public abstract void ClearDependencies();
        public abstract T GetSystemUnderTest();
    }
}
