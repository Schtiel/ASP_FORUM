namespace ASP_FORUM.Common
{
	public class TaskResult
	{
		public bool Success { get; }
		public string? Error { get; }

		protected TaskResult(bool success, string? error)
		{
			Success = success;
			Error = error;
		}

		public static TaskResult Ok() => new(true, null);
		public static TaskResult Fail(string error) => new(false, error);
	}

	public class TaskResult<T>
	{
		public bool Success { get; }
		public string? Error { get; }
		public T? Data { get; }

		private TaskResult(T data)
		{
			Success = true;
			Data = data;
			Error = null;
		}

		private TaskResult(string error)
		{
			Success = false;
			Error = error;
			Data = default;
		}

		public static TaskResult<T> Ok(T data) => new(data);
		public static TaskResult<T> Fail(string error) => new(error);
	}
}
