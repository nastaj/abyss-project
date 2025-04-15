using UnityEngine;
using UnityEngine.Playables;
using KinematicCharacterController;

public class CutsceneTrigger : MonoBehaviour
{
    public PlayableDirector cutscene;
    public CutsceneDialogue cutsceneDialogue;

    public Camera cutsceneCamera;   // Reference to the cutscene camera
    public Camera playerCamera;     // Reference to the player's camera
    public GameObject skipPromptUI; // Reference to the skip UI prompt

    private bool hasPlayed = false;
    private GameObject player;
    private PlayerCharacterController playerController;
    private KinematicCharacterMotor motor;

    void Update()
    {
        if (CutsceneManager.Instance != null && CutsceneManager.Instance.IsPlayingCutscene && Input.GetKeyDown(KeyCode.Escape))
        {
            SkipCutscene();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!hasPlayed && other.CompareTag("Player"))
        {
            player = other.gameObject;
            playerController = player.GetComponentInChildren<PlayerCharacterController>();
            motor = player.GetComponentInChildren<KinematicCharacterMotor>();

            if (playerController != null && motor != null)
            {
                playerController.enabled = false;
                motor.enabled = false;
            }

            // Switch cameras
            if (cutsceneCamera != null && playerCamera != null)
            {
                cutsceneCamera.gameObject.SetActive(true);
                playerCamera.gameObject.SetActive(false);
            }

            // Show skip UI
            if (skipPromptUI != null)
            {
                skipPromptUI.SetActive(true);
            }

            cutscene.Play();
            cutsceneDialogue.StartDialogue();
            cutscene.stopped += OnCutsceneEnd;

            CutsceneManager.Instance.SetCutsceneState(true);
            hasPlayed = true;
        }
    }

    void SkipCutscene()
    {
        Debug.Log(cutscene.state == PlayState.Playing);
        if (cutscene != null && cutscene.state == PlayState.Playing)
        {
            cutscene.Stop(); // Will call OnCutsceneEnd
        }
    }

    private void OnCutsceneEnd(PlayableDirector director)
    {
        // Re-enable movement
        if (playerController != null && motor != null)
        {
            playerController.enabled = true;
            motor.enabled = true;
        }

        // Switch back to player camera
        if (cutsceneCamera != null && playerCamera != null)
        {
            cutsceneCamera.gameObject.SetActive(false);
            playerCamera.gameObject.SetActive(true);
        }

        // Hide skip UI
        if (skipPromptUI != null)
        {
            skipPromptUI.SetActive(false);
        }

        cutsceneDialogue.EndDialogue();
        cutscene.stopped -= OnCutsceneEnd;
        CutsceneManager.Instance.SetCutsceneState(false);
    }
}
