using UnityEngine;
using TMPro;
using System.Collections;
using SmallHedge.SoundManager;

public class CutsceneDialogue : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public GameObject dialogueBackdrop; // The backdrop (e.g. a panel with text background)
    public float typingSpeed = 0.05f;

    [TextArea(3, 5)]
    public string[] dialogueLines;
    public float[] lineDelays;

    private Coroutine dialogueCoroutine;

    public void StartDialogue()
    {
        dialogueBackdrop.SetActive(true);
        dialogueCoroutine = StartCoroutine(PlayDialogue());
    }

    public void EndDialogue()
    {
        if (dialogueCoroutine != null)
            StopCoroutine(dialogueCoroutine);

        dialogueText.text = "";
        dialogueBackdrop.SetActive(false);
    }

    IEnumerator PlayDialogue()
    {
        for (int i = 0; i < dialogueLines.Length; i++)
        {
            yield return StartCoroutine(TypeLine(dialogueLines[i]));
            yield return new WaitForSeconds(lineDelays[i]);
        }

        // Optionally auto-hide at the end
        EndDialogue();
    }

    IEnumerator TypeLine(string line)
    {
        dialogueText.text = "";

        foreach (char letter in line.ToCharArray())
        {
            dialogueText.text += letter;
            SoundManager.PlaySound(SoundType.DIALOGUE_TYPE);
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
