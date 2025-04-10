using UnityEngine;
using UnityEngine.Playables;

public class CutsceneTrigger : MonoBehaviour
{
    public PlayableDirector cutscene;
    private bool hasPlayed = false;

    void OnTriggerEnter(Collider other)
    {
        if (!hasPlayed && other.CompareTag("Player"))
        {
            Debug.Log("Cutscene entered");
            cutscene.Play();
            hasPlayed = true;
        }
    }
}