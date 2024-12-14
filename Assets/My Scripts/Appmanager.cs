using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ApplicationData
{
    public static float NumShot;//number of shots fired
    public static float NumHit;//number of alraedy hit
    public static float NumMax;//max number of shots per game
    public static float Percent;//percent of success, current round
    public static float Best;//best score ever, stored
}


public class Appmanager : MonoBehaviour
{
    private float RandomInterval;
    private float RandomX;
    private float RandomY;

    private float RandomZforce;
    private float RandomXforce;

    public GameObject CatchMe;

    public GameObject NumShotDisplay;
    public GameObject NumHitDisplay;
    public GameObject NumPercentDisplay;
    public GameObject BestScoreDisplay;

    private string ShotToString;
    private string HitToString;
    private string PercentToString;
    private string BestToString;

    void Start()
    {
        ApplicationData.NumShot = 0;
        ApplicationData.NumHit = 0;
        ApplicationData.NumMax = 50;
        ApplicationData.Best = PlayerPrefs.GetFloat("BestScore", 0);
        BestToString = ApplicationData.Best.ToString("P1");
        BestScoreDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = BestToString;
        NumPercentDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = "0.0%";//reset scrore display
        Invoke("GenerateNew", 2f);
    }

    void GenerateNew()
    {
        if (ApplicationData.NumShot < ApplicationData.NumMax)//if fewer than max were shot so far....
        {
            RandomX = Random.Range(-2.5f, 2.5f);
            if (RandomX > -0.5f && RandomX < 0.5f)
            {
                RandomX = RandomX * 5f;

            }
            //print(RandomX);
            RandomY = Random.Range(0.9f, 2.3f);

            RandomZforce = -(Random.Range(0f, 1f) + 4f);
            RandomXforce = Random.Range(-0.9f, 0.9f);

            GameObject NewShot = Instantiate(CatchMe, new Vector3(RandomX, RandomY, 20), Quaternion.identity);
            NewShot.GetComponent<ConstantForce>().relativeForce = new Vector3(RandomXforce, 0, RandomZforce);


            ApplicationData.NumShot++;
            if (ApplicationData.NumShot < 10)//if single digit
            {
                ShotToString = "0" + ApplicationData.NumShot.ToString();//pad 0
            }
            else
            {//double digit
                ShotToString = ApplicationData.NumShot.ToString();//as is
            }

            NumShotDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = ShotToString;

            RandomInterval = Random.Range(0.5f, 2f);
            Invoke("GenerateNew", RandomInterval);
        }//end if less than max



    }

    void Update()
    {
        ///display hits////////////////////////////////////////////////////////
        if (ApplicationData.NumHit < 10)//if single digit
        {
            HitToString = "0" + ApplicationData.NumHit.ToString();//pad 0
        }
        else
        {//double digit
            HitToString = ApplicationData.NumHit.ToString();//as is
        }


        NumHitDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = HitToString;
        ///////////////////////////////////////////////////////////////////////


        ////display percent//////////
        if (ApplicationData.NumShot > 0f)
        {
            ApplicationData.Percent = (ApplicationData.NumHit / ApplicationData.NumShot);
            //  print(ApplicationData.Percent);
        }

        PercentToString = ApplicationData.Percent.ToString("P1");
        NumPercentDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = PercentToString;
        ////////////////////////////////////////////////////////////////////////////


    }
}//end class
