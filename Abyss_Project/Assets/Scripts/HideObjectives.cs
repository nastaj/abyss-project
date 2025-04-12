using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HideObjectives : MonoBehaviour
{
    public GameObject objectivesPanel; // Drag the parent object here in the inspector

    public void HideTextInObjectives(GameObject panel)
    {
        Debug.Log("Clearing UI...");

        // Unity UI Text
        Text[] uiTexts = panel.GetComponentsInChildren<Text>(true);
        foreach (Text t in uiTexts)
        {
            t.enabled = false;
        }

        // TextMeshProUGUI
        TextMeshProUGUI[] tmpTexts = panel.GetComponentsInChildren<TextMeshProUGUI>(true);
        foreach (TextMeshProUGUI tmp in tmpTexts)
        {
            tmp.enabled = false;
        }
    }
}