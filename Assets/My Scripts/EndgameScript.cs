using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // to navigate scenes
using TMPro; // to work with TextMeshPro

public class EndgameScript : MonoBehaviour
{
    public GameObject BestScoreDisplay; // To display the best score
    public GameObject NumPercentDisplay; // To display the percent hit
    public GameObject RightHandScoreDisplay; // To display right-hand catches
    public GameObject LeftHandScoreDisplay; // To display left-hand catches

    private string PercentToString;

    // Start is called before the first frame update
    void Start()
    {
        // Convert Percent to string format
        PercentToString = ApplicationData.Percent.ToString("P1");
        NumPercentDisplay.GetComponent<TextMeshProUGUI>().text = PercentToString;

        // Display Best Score
        getBestScore();

        // Display the Left and Right hand scores
        DisplayHandScores();
    }

    void getBestScore()
    {
        // Fetch the best score from PlayerPrefs (default is 0 if not found)
        ApplicationData.Best = PlayerPrefs.GetFloat("BestScore", 0);

        if (ApplicationData.Best > 0)
        {
            BestScoreDisplay.GetComponent<TextMeshProUGUI>().text = ApplicationData.Best.ToString("P1");
        }
        else
        {
            BestScoreDisplay.GetComponent<TextMeshProUGUI>().text = "First Time player, no best score yet!";
        }
    }

    void DisplayHandScores()
    {
        // Fetch right-hand and left-hand scores from PlayerPrefs
        int rightHandScore = PlayerPrefs.GetInt("RightHandScore", 0);
        int leftHandScore = PlayerPrefs.GetInt("LeftHandScore", 0);

        // Display scores using TextMeshPro
        RightHandScoreDisplay.GetComponent<TextMeshProUGUI>().text = "Right-hand catches: " + rightHandScore;
        LeftHandScoreDisplay.GetComponent<TextMeshProUGUI>().text = "Left-hand catches: " + leftHandScore;
    }

    // Update is called once per frame
    void Update()
    {
        // To reload the game
        if (OVRInput.Get(OVRInput.RawButton.LIndexTrigger) ||
            OVRInput.Get(OVRInput.RawButton.RIndexTrigger) ||
            Input.GetKeyDown(KeyCode.B)) // B key for testing in Unity
        {
            SceneManager.LoadScene("Workout_Main"); // Reload main game scene
        }

        // Developer's cheat to reset the best score
        if ((OVRInput.Get(OVRInput.RawButton.X) &&
             OVRInput.Get(OVRInput.RawButton.A)) ||
             Input.GetKeyDown(KeyCode.C)) // C key for testing reset in Unity
        {
            PlayerPrefs.SetFloat("BestScore", 0f);
            SceneManager.LoadScene("Workout_Intro"); // Go back to intro scene
        }
    }
}