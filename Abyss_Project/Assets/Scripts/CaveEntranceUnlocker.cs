using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class CaveEntranceUnlocker : MonoBehaviour
{
    public Collider caveEntranceCollider;
    private bool isUnlocked = false;
    private PlayerInventory playerInventory;

    void Start()
    {
        // Assuming PlayerInventory is attached to the same GameObject or another GameObject
        playerInventory = FindObjectOfType<PlayerInventory>();

        if (playerInventory != null)
        {
            // Subscribe to inventory events to check if objectives are complete
            playerInventory.OnAppleCollected.AddListener(CheckObjectiveCompletion);
            playerInventory.OnMushroomCollected.AddListener(CheckObjectiveCompletion);
            playerInventory.OnSampleCollected.AddListener(CheckObjectiveCompletion);
            playerInventory.OnMeatCollected.AddListener(CheckObjectiveCompletion);
            playerInventory.OnSurveyCollected.AddListener(CheckObjectiveCompletion);
        }
    }

    void CheckObjectiveCompletion(PlayerInventory inventory)
    {
        if (!isUnlocked && ObjectiveManager.Instance.AreAllObjectivesComplete())
        {
            UnlockCave();
        }
    }

    void UnlockCave()
    {
        caveEntranceCollider.enabled = true;
        isUnlocked = true;
        Debug.Log("Cave entrance is now unlocked!");
    }
}