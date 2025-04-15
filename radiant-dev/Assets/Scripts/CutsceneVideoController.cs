using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio; // Needed for controlling mixers

public class CutsceneVideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public RawImage rawImage;
    public GameObject videoPanel;
    public AudioMixer audioMixer; // Drag your mixer here
    public string ambienceVolumeParameter = "AmbienceVolume"; // Must match exposed name
    public Timer timerScript;           // Reference to the Timer script
    public GameObject timerUI;         // The UI object that displays the time

    void Start()
    {
        videoPanel.SetActive(false);
    }

    public void PlayEndCutscene()
    {
         // Stop the timer logic
        if (timerScript != null)
            timerScript.enabled = false;

        // Hide the timer UI
        if (timerUI != null)
            timerUI.SetActive(false);

        videoPanel.SetActive(true);
        videoPlayer.Play();

        // Mute ambience (set volume to -80 dB, which is silence)
        audioMixer.SetFloat(ambienceVolumeParameter, -80f);
    }

    public void OnVideoFinished(VideoPlayer vp)
    {
        videoPanel.SetActive(false);
        SceneManager.LoadScene("EndMenu");

        // Optionally restore ambience volume if needed
        audioMixer.SetFloat(ambienceVolumeParameter, 0f); // 0 dB is full volume

        Debug.Log("Cutscene Finished!");
    }

    void OnEnable()
    {
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    void OnDisable()
    {
        videoPlayer.loopPointReached -= OnVideoFinished;
    }
}
