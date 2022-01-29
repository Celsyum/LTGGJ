using UnityEngine;
using GGJ.Core;

public class GameManager : MonoBehaviour
{
	public GameStats stats = Game.GetModel<GameStats>();

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

    public GameObject Player { get => player; }
}