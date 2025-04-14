using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;  // Unlocks the cursor
        Cursor.visible = true;                   // Makes the cursor visible
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Forest");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
