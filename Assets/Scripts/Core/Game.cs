namespace GGJ.Core
{

	public static partial class Game
	{
		static public T GetModel<T>() where T : class, new()
		{
			return InstanceRegister<T>.instance;
		}

		static public void SetModel<T>(T instance) where T : class, new()
		{
			InstanceRegister<T>.instance = instance;
		}

		static public void DestroyModel<T>() where T : class, new()
		{
			InstanceRegister<T>.instance = null;
		}
	}

}
