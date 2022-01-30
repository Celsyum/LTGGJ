using GGJ.Core;
using System.Collections;
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
		this.GetComponent<AudioSource>().Play();
		StartCoroutine(loadScene(levelName));
	}

	IEnumerator loadScene(string levelName)
	{
		yield return new WaitForSeconds(.5f);
		SceneManager.LoadScene(levelName, LoadSceneMode.Single);
	}
}
