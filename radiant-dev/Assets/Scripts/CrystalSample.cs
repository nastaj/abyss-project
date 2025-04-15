using UnityEngine;

public class CrystalSample : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponentInParent<PlayerInventory>();

        if (playerInventory != null)
        {
            playerInventory.SampleCollected();
            gameObject.SetActive(false);
        }
    }
}
