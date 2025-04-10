using UnityEngine;

public class Survey : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponentInParent<PlayerInventory>();

        if (playerInventory != null)
        {
            playerInventory.SurveyCollected();
            gameObject.SetActive(false);
        }
    }
}
