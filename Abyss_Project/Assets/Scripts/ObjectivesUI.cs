using UnityEngine;
using TMPro;

public class ObjectivesUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI counter;
    [SerializeField]
    private TextMeshProUGUI description;

   void Start()
   {
        if (description.text.Contains("Grab sword") || description.text.Contains("Enter cave"))
        {
            counter.enabled = false;
            description.enabled = false;
        }

   }

   public void UpdateAppleQuest(PlayerInventory playerInventory)
   {
        counter.text = playerInventory.NumberOfApples.ToString();

        if (playerInventory.NumberOfApples == 10)
        {
            counter.text = "";
            description.text = "- Done";
        }
   }

   public void UpdateMushroomQuest(PlayerInventory playerInventory)
   {
        counter.text = playerInventory.NumberOfMushrooms.ToString();

        if (playerInventory.NumberOfMushrooms == 3)
        {
            counter.text = "";
            description.text = "- Done";
        }
   }

    public void UpdateSampleQuest(PlayerInventory playerInventory)
   {
        counter.text = playerInventory.NumberOfSamples.ToString();

        if (playerInventory.NumberOfSamples == 2)
        {
            counter.text = "";
            description.text = "- Done";
        }
   }

    public void UpdateMeatQuest(PlayerInventory playerInventory)
   {
        counter.text = playerInventory.NumberOfMeat.ToString();

        if (playerInventory.NumberOfMeat == 1)
        {
            counter.text = "";
            description.text = "- Done";
        }
   }

    public void UpdateSurveyQuest(PlayerInventory playerInventory)
   {
        counter.text = playerInventory.NumberOfSurveys.ToString();

        if (playerInventory.NumberOfSurveys == 1)
        {
            counter.text = "";
            description.text = "- Done";
        }
   }

    public void UpdateSwordQuest(PlayerInventory playerInventory)
   {
        counter.text = playerInventory.NumberOfSwords.ToString();

        if (playerInventory.NumberOfSwords == 1)
        {
            counter.text = "";
            description.text = "- Done";
        }
   }

   public void ShowSwordQuest()
   {
        if (description.text.Contains("Grab sword"))
        {
            counter.enabled = true;
            description.enabled = true;
        }
   }

   public void ShowCaveQuest()
   {
        if (description.text.Contains("Enter cave"))
        {
            counter.enabled = true;
            description.enabled = true;
        }
   }

   void OnEnable()
    {
        ObjectiveManager.OnBasicObjectivesCompleted += ShowSwordQuest;
        ObjectiveManager.OnSwordGrabbed += ShowCaveQuest;
    }

    void OnDisable()
    {
        ObjectiveManager.OnBasicObjectivesCompleted -= ShowSwordQuest;
        ObjectiveManager.OnSwordGrabbed += ShowCaveQuest;
    }
}
