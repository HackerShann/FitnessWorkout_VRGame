using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WallScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision WhatHit)
    {


        if (WhatHit.gameObject.CompareTag("CatchMe"))//if an catchme hit the wall- destroy it
        {

            Destroy(WhatHit.gameObject);//destroy the injector that hit the wall


        }//end if a shot hit the wall


        if (ApplicationData.NumShot >= ApplicationData.NumMax)
        {
            // print(ApplicationData.NumShot);
            Invoke("Endgame", 2);
        }

    }//end collision enter

    void Endgame()
    {
        float currentScore = ApplicationData.NumHit / ApplicationData.NumShot;
        print("best until now is " + ApplicationData.Best);
        print("score this round " + currentScore);
        if (currentScore > ApplicationData.Best)//if new best....
        {
            ApplicationData.Best = currentScore;
            print("new best is " + ApplicationData.Best);

            SetPersist("BestScore", ApplicationData.Best);


        }//end if new best

        void SetPersist(string varname, float value)
        {
            PlayerPrefs.SetFloat(varname, value);

        }
        SceneManager.LoadScene("Workout_Endgame");//go to loading scene
    }
}


