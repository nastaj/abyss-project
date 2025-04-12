using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    public static event System.Action OnBasicObjectivesCompleted;
    public static event System.Action OnSwordGrabbed;
    public static ObjectiveManager Instance;
    public GameObject sword;
    private PlayerInventory playerInventory; // Reference to the player's inventory
    public HideObjectives hideObjectives; // Reference to the objective hiding functionality
    public bool isCaveEntered {get; private set;} = false;

    private void Awake()
    {
        Instance = this;
        playerInventory = FindObjectOfType<PlayerInventory>();

        if (hideObjectives == null)
        {
            hideObjectives = GetComponent<HideObjectives>() ?? FindObjectOfType<HideObjectives>();
        }
    }

    public bool AreBasicObjectivesComplete()
    {
        bool complete = playerInventory.NumberOfApples >= 10 &&
                        playerInventory.NumberOfMushrooms >= 3 &&
                        playerInventory.NumberOfSamples >= 2 &&
                        playerInventory.NumberOfMeat >= 1 &&
                        playerInventory.NumberOfSurveys >= 1;

        if (complete)
        {
            hideObjectives.HideTextInObjectives(hideObjectives.objectivesPanel);

            // Trigger event
            OnBasicObjectivesCompleted?.Invoke();

            // Enable the sword trigger if all objectives are complete
            EnableSwordTrigger();
        }

        if (IsSwordCollected())
        {
            OnSwordGrabbed?.Invoke();
        }

        return complete;
    }

    public bool IsSwordCollected()
    {
        return playerInventory.NumberOfSwords >= 1;
    }

    public void CaveEntered()
    {
        isCaveEntered = true;
    }

    private void EnableSwordTrigger()
    {
        // Ensure sword's collider is disabled initially
        if (sword != null)
        {
            Collider swordCollider = sword.GetComponent<Collider>();

            if (swordCollider != null && !swordCollider.enabled)
            {
                swordCollider.enabled = true; // Enable collider to allow interaction
            }
        }
    }
}