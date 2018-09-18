namespace Wil.Testing
{
    public static class TestInitializer
    {
        public static void Initialize(IAssert asserter, ICollectionAssert collectionAsserter)
        {
            Assert.Initialize(asserter);
            CollectionAssert.Initialize(collectionAsserter);
        }
    }
}
