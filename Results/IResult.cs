using System.Collections.Generic;

namespace Results
{
    public interface IResult
	{
		bool HasErrors { get; }

		bool IsValid { get; }

		IEnumerable<string> GetErrorMessages();

		string GetErrorSummary();
	}

	public interface IResult<TError> : IResult
    {
		ICollection<TError> Errors { get; }
    }
}
