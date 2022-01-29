using UnityEngine;
using GGJ.Core;

public class GameManager : MonoBehaviour
{
	
	private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    [SerializeField] private GameObject player;
	[SerializeField] private GameStats _stats;

	public GameObject Player { get => player; }
	public GameStats stats {
		get => _stats;
		set
		{
			_stats = value;
		}
	}

	void Awake()
	{
		if (GameManager.instance != null)
		{ 
			Destroy(this.gameObject);
			return;
		}

		
		DontDestroyOnLoad(this.gameObject);
	}

}