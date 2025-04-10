using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    public static ObjectiveManager Instance;
    public PlayerInventory playerInventory; // Reference to the player's inventory

    private void Awake()
    {
        Instance = this;
    }

    public bool AreAllObjectivesComplete()
    {
        return playerInventory.NumberOfApples >= 10 &&
               playerInventory.NumberOfMushrooms >= 3 &&
               playerInventory.NumberOfSamples >= 2 &&
               playerInventory.NumberOfMeat >= 1 &&
               playerInventory.NumberOfSurveys >= 1;
    }
}