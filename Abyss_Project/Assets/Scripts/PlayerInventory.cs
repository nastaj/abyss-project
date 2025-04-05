using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfApples {get; private set; }

    public UnityEvent<PlayerInventory> OnAppleCollected;

    public void AppleCollected()
    {
        NumberOfApples++;
        OnAppleCollected.Invoke(this);
    }
}
