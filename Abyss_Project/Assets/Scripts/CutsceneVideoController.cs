using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class CutsceneVideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;   // Drag the VideoPlayer component here
    public RawImage rawImage;         // Drag the RawImage component here
    public GameObject videoPanel;     // Drag the UI Panel here to activate during video playback

    void Start()
    {
        // Make sure the video panel is inactive at the start
        videoPanel.SetActive(false);
    }

    public void PlayEndCutscene()
    {
        // Activate the video panel (it will be visible now)
        videoPanel.SetActive(true);

        // Play the video
        videoPlayer.Play();
    }

    // Called when the video finishes playing
    public void OnVideoFinished(VideoPlayer vp)
    {
        // Do something after the video ends (e.g., transition to the next scene)
        videoPanel.SetActive(false);  // Hide the video panel after video ends
        Debug.Log("Cutscene Finished!");
    }

    void OnEnable()
    {
        // Subscribe to the event that gets triggered when the video finishes
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    void OnDisable()
    {
        // Unsubscribe from the event when the object is disabled or destroyed
        videoPlayer.loopPointReached -= OnVideoFinished;
    }
}