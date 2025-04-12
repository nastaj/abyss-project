using UnityEngine;
using UnityEngine.Playables;

public class CutsceneTrigger : MonoBehaviour
{
    public PlayableDirector cutscene;
    public CutsceneDialogue cutsceneDialogue;
    private bool hasPlayed = false;

    void OnTriggerEnter(Collider other)
    {
        if (!hasPlayed && other.CompareTag("Player"))
        {
            Debug.Log("Cutscene entered");
            
            // Play cutscene and dialogue
            cutscene.Play();
            cutsceneDialogue.StartDialogue();

            // Subscribe to the cutscene end event
            cutscene.stopped += OnCutsceneEnd;

            hasPlayed = true;
        }
    }

    // Callback for when the cutscene finishes
    private void OnCutsceneEnd(PlayableDirector director)
    {
        // Hide the dialogue backdrop and stop the typing
        cutsceneDialogue.EndDialogue();

        // Unsubscribe to avoid future callbacks
        cutscene.stopped -= OnCutsceneEnd;
    }
}