using GGJ.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void StartGame(string levelName)
	{
		SceneManager.LoadScene(levelName, LoadSceneMode.Single);
	}
}
