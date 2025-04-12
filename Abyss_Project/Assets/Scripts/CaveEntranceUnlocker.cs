using UnityEngine;
using UnityEngine.Events;

public class CaveEntranceUnlocker : MonoBehaviour
{
    public Collider caveEntranceCollider;
    private bool isUnlocked = false;
    private PlayerInventory playerInventory;

    void Awake()
    {
        // Automatically find the PlayerInventory if not assigned manually
        playerInventory = FindObjectOfType<PlayerInventory>();
    }

    void Start()
    {
        if (playerInventory != null)
        {
            // Subscribe to inventory events
            playerInventory.OnAppleCollected.AddListener(CheckObjectiveCompletion);
            playerInventory.OnMushroomCollected.AddListener(CheckObjectiveCompletion);
            playerInventory.OnSampleCollected.AddListener(CheckObjectiveCompletion);
            playerInventory.OnMeatCollected.AddListener(CheckObjectiveCompletion);
            playerInventory.OnSurveyCollected.AddListener(CheckObjectiveCompletion);
            playerInventory.OnSwordCollected.AddListener(CheckObjectiveCompletion);
        }
        else
        {
            Debug.LogWarning("PlayerInventory reference not set on CaveEntranceUnlocker.");
        }
    }

    void CheckObjectiveCompletion(PlayerInventory inventory)
    {
        if (!isUnlocked &&
            ObjectiveManager.Instance != null &&
            ObjectiveManager.Instance.AreBasicObjectivesComplete() &&
            ObjectiveManager.Instance.IsSwordCollected())
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