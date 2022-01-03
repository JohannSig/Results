namespace Results.Tests
{
    public class UnitTestResult : Result<UnitTestError>
    {
        public override string GetErrorMessage(UnitTestError error)
        {
            return error switch
            {
                UnitTestError.SomeError => $"Some kind of error happened",

                UnitTestError.AnotherError => $"Another kind of error happened",

                _ => base.GetErrorMessage(error),
            };
        }
    }
}
