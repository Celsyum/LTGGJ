namespace GGJ.Core
{

	public static partial class Game
	{
		static class InstanceRegister<T> where T : class, new()
		{
			public static T instance = new T();
		}
	}
}
