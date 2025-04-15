using UnityEngine;

public class Meat : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponentInParent<PlayerInventory>();

        if (playerInventory != null)
        {
            playerInventory.MeatCollected();
            gameObject.SetActive(false);
        }
    }
}
