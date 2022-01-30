using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private string musicTrack = "MenuMusic";

    void Start()
    {
        AudioPlayer.Instance.PlayMusic(musicTrack);
    }
}