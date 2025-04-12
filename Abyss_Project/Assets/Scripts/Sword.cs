using UnityEngine;

public class Sword : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponentInParent<PlayerInventory>();

        if (playerInventory != null)
        {
            playerInventory.SwordCollected();
            gameObject.SetActive(false);
        }
    }
}
