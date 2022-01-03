using System;
using System.Collections.Generic;
using System.Linq;

namespace Results
{
    public class Result<TError> : IResult<TError>
	   where TError : struct
	{
		public bool HasErrors => this.Errors.Count > 0;

		public bool IsValid => !this.HasErrors;

		public ICollection<TError> Errors { get; init; } = new HashSet<TError>();

		/// <summary>
		/// Adds an error to the <see cref="Errors"/> collection.
		/// </summary>
		public TError Error { init => this.Errors.Add(value); }

        public bool HasError(TError error)
        {
            return this.Errors.Contains(error);
        }

		/// <summary>
		/// Joins entries from <see cref="GetErrorMessages()"/> into a single string.
		/// </summary>
		/// <returns></returns>
		public string GetErrorSummary(Func<Result<TError>, string> summaryFunc)
		{
			return summaryFunc(this);
		}

		/// <summary>
		/// Joins entries from <see cref="GetErrorMessages()"/> into a single, line-separated string.
		/// </summary>
		/// <returns></returns>
		public string GetErrorSummary()
        {
			return GetErrorSummary(x => string.Join(Environment.NewLine, x.GetErrorMessages()));
        }

		/// <summary>
		/// Returns an enumerable for <see cref="Errors"/> after being projected using <see cref="GetErrorMessage(TError)"/>.
		/// </summary>
		/// <returns></returns>
		public IEnumerable<string> GetErrorMessages()
		{
			return this.Errors.Select(this.GetErrorMessage);
		}

		public virtual string GetErrorMessage(TError error)
        {
			return error.ToString();
        }
	}
}
