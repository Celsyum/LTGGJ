using UnityEngine;
using GGJ.Core;

/**
 * @author Tadas aka Celsyum
 * */
public class GameManageController : MonoBehaviour
{
	public GameStats model = Game.GetModel<GameStats>();

	private static GameManageController instance;

	public static GameManageController Instance
	{
		get
		{
			if (Instance == null)
			{
				instance = FindObjectOfType<GameManageController>();
			}
			return Instance;
		}
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

	void OnEnable()
	{
		
	}

	void OnDisable()
	{
		
	}
}
