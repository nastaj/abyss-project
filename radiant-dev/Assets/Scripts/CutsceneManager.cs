using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    public static CutsceneManager Instance { get; private set; }

    public bool IsPlayingCutscene { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Only one instance allowed
        }
        else
        {
            Instance = this;
        }
    }

    public void SetCutsceneState(bool isPlaying)
    {
        Debug.Log($"CutsceneManager: SetCutsceneState({isPlaying})");
        IsPlayingCutscene = isPlaying;
    }
}
