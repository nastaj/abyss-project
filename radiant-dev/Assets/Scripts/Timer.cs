using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  // Add this to use the UI system
using TMPro;

public class Timer : MonoBehaviour
{
    //-------------------------
    //Maximum time to complete level (in seconds)
    public float MaxTime = 5f;
    //-------------------------
    //Countdown
    [SerializeField]
    private float CountDown = 0;
    //-------------------------
    
    // Reference to the UI Text element
    public TextMeshProUGUI timerText; // Drag your Text UI element here in the Inspector

    //-------------------------
    // Use this for initialization
    void Start() 
    {
        CountDown = MaxTime;
    }

    //-------------------------
    // Update is called once per frame
    void Update() 
    {
        //Reduce time
        CountDown -= Time.deltaTime;

        // Format the time (minutes:seconds)
        int minutes = Mathf.FloorToInt(CountDown / 60);
        int seconds = Mathf.FloorToInt(CountDown % 60);

        // Update the UI Text
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        // Restart level if time runs out
        if(CountDown <= 0)
        {
            SceneManager.LoadScene("EndMenu");
        }
    }
    //-------------------------
}