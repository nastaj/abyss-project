using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI appleText;

    void Start()
    {
        appleText = GetComponent<TextMeshProUGUI>();
    }

   public void UpdateAppleText(PlayerInventory playerInventory)
   {
        appleText.text = playerInventory.NumberOfApples.ToString();
   }
}
