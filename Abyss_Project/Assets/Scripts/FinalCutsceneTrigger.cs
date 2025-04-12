using UnityEngine;

public class FinalCutsceneTrigger : MonoBehaviour
{
   void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Final cutscene entered");
            FindObjectOfType<CutsceneVideoController>().PlayEndCutscene();
        }
    }
}
