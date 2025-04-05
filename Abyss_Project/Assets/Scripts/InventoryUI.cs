using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI counter;
    [SerializeField]
    private TextMeshProUGUI description;

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
}
