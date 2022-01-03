using Xunit;

namespace Results.Tests
{
    public class UnitTests
    {
        [Fact]
        public void ResultDefaultsToSuccess()
        {
            var result = GetTestResult();

            Assert.True(result.IsValid);
            Assert.False(result.HasErrors);
        }

        [Fact]
        public void ResultShowsIfError()
        {
            var result = GetTestResultWithError();

            Assert.False(result.IsValid);
            Assert.True(result.HasErrors);
            Assert.True(result.HasError(UnitTestError.SomeError));
            Assert.False(result.HasError(UnitTestError.AnotherError));
        }

        [Fact]
        public void ErrorMessageAsExpected()
        {
            const string expectedErrorMessage = "Some kind of error happened";

            var result = GetTestResultWithError();

            Assert.Contains(expectedErrorMessage, result.GetErrorMessages());
            Assert.Equal(expectedErrorMessage, result.GetErrorSummary());
        }


        private static UnitTestResult GetTestResult()
        {
            return new();
        }

        private static UnitTestResult GetTestResultWithError()
        {
            return new UnitTestResult
            {
                Error = UnitTestError.SomeError,
            };
        }
    }
}
