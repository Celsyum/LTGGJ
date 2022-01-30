using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectController : MonoBehaviour
{
	public void LoadScene(int sceneId)
	{
		SceneManager.LoadScene(sceneId);
	}

	public void ExitGame()
	{
		Application.Quit();
	}

	public void StartGame(string levelName)
	{
		GetComponent<AudioSource>().Play();
		StartCoroutine(LoadLevel(levelName));
	}

	private IEnumerator LoadLevel(string levelName)
	{
		yield return new WaitForSeconds(.5f);
		SceneManager.LoadScene(levelName, LoadSceneMode.Single);
	}
}