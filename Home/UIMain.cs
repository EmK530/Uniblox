using TMPro;
using UnityEngine;

public class UIMain : MonoBehaviour
{
    public GameObject root;
    public TextMeshProUGUI statusText;
    public AudioSource music;

    void Awake()
    {
        GameLoader.GameLoaderStatus.AddListener(StatusSignal);
        GameLoader.GameLoadCompleted.AddListener(Hide);
    }

    void StatusSignal(string text)
    {
        statusText.text = text;
    }

    void Hide()
    {
        root.SetActive(false);
        music.Stop();
    }
}
