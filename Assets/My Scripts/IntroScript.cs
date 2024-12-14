using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//to be able to navigate scenes

public class IntroScript : MonoBehaviour
{
    public GameObject BestScoreDisplay;

    // Start is called before the first frame update
    void Start()
    {
        getBestScore();
    }

    void getBestScore()
    {
        //Fetch var from the PlayerPrefs If no float of this name exists, the default is 0
        ApplicationData.Best = PlayerPrefs.GetFloat("BestScore", 0);

        if (ApplicationData.Best > 0)
        {
            BestScoreDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = ApplicationData.Best.ToString("P1");
        }
        else
        {
            BestScoreDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = "First Time player, no best score yet!";
        }
    }


    // Update is called once per frame
    void Update()
    {

        ///to start game///////////
        if (OVRInput.Get(OVRInput.RawButton.LIndexTrigger) ||
            OVRInput.Get(OVRInput.RawButton.RIndexTrigger) ||
            Input.GetKeyDown(KeyCode.B))//the b key is so we can test in unity before building
        {

            SceneManager.LoadScene("Workout_Loading");//go to loading scene

        }//end if trigger


        ///DEVELOPER'S RESET BEST SCORE CHEAT///////////
        if ((OVRInput.Get(OVRInput.RawButton.X) &&
            OVRInput.Get(OVRInput.RawButton.A)) ||
            Input.GetKeyDown(KeyCode.C))//the b key is so we can test in unity before building
        {
            PlayerPrefs.SetFloat("BestScore", 0f);
            SceneManager.LoadScene("Workout_Intro");//go to loading scene

        }//end if X+A or key cheat


    }//end update
}
