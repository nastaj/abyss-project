using UnityEngine;
using TMPro;

public class ObjectiveManager : MonoBehaviour
{
    public static event System.Action OnBasicObjectivesCompleted;
    public static event System.Action OnSwordGrabbed;
    public static event System.Action OnSurveyComplete;
    public static ObjectiveManager Instance;
    public GameObject sword;
    public GameObject apples;
    public GameObject meat;
    public GameObject mushrooms;
    public GameObject samples;
    public TextMeshProUGUI objectivesBrief;
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

    void Start()
    {
        apples.SetActive(false);
        meat.SetActive(false);
        mushrooms.SetActive(false);
        samples.SetActive(false);
    }

    public bool AreBasicObjectivesComplete()
    {
        if (IsSurveyComplete())
        {
            apples.SetActive(true);
            meat.SetActive(true);
            mushrooms.SetActive(true);
            samples.SetActive(true);

            objectivesBrief.text = "There seems to be something wrong about this place. I need to gather samples from the area.";

            OnSurveyComplete?.Invoke();
        }

        bool complete = playerInventory.NumberOfApples >= 10 &&
                        playerInventory.NumberOfMushrooms >= 3 &&
                        playerInventory.NumberOfSamples >= 2 &&
                        playerInventory.NumberOfMeat >= 1 &&
                        playerInventory.NumberOfSurveys >= 1;

        if (complete)
        {
            hideObjectives.HideTextInObjectives(hideObjectives.objectivesPanel);

            objectivesBrief.text = "It looks like the corruption has its roots in the caves. Researchers were right to be cautious - I should get ready and investigate.";

            // Trigger event
            OnBasicObjectivesCompleted?.Invoke();

            // Enable the sword trigger if all objectives are complete
            EnableSwordTrigger();
        }

        if (IsSwordCollected())
        {
            objectivesBrief.text = "I got everything. Let's go inside.";

            OnSwordGrabbed?.Invoke();
        }

        return complete;
    }

    public bool IsSwordCollected()
    {
        return playerInventory.NumberOfSwords >= 1;
    }

    public bool IsSurveyComplete()
    {
        return playerInventory.NumberOfSurveys >= 1;
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