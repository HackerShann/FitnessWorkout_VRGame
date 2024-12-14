using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatchMeScript : MonoBehaviour
{
    public GameObject flying;
    public GameObject caught;
    private bool FirstHit; // to ensure only one contact, impact

    public int RightHandCatches = 0; // Track right-hand catches
    public int LeftHandCatches = 0;  // Track left-hand catches

    void Start()
    {
        FirstHit = false; // Not caught yet
    }

    void OnCollisionEnter(Collision WhatHit)
    {
        // Check if the flying object hit the right hand ("Rrack")
        if (WhatHit.gameObject.CompareTag("Rrack") && FirstHit == false)
        {
            FirstHit = true; // Mark as hit
            ApplicationData.NumHit++; // Update the app data
            RightHandCatches++; // Increment right-hand catch count

            flying.SetActive(false); // Hide flying object
            caught.SetActive(true); // Show caught object
            OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.RTouch); // Start vibration
            Invoke("StopVibration", 0.1f); // Stop vibration after 0.1 seconds
            Invoke("DestroyCaughtBall", 2f); // Destroy caught ball after 2 seconds
        }

        // Check if the flying object hit the left hand ("Lrack")
        if (WhatHit.gameObject.CompareTag("Lrack") && FirstHit == false)
        {
            FirstHit = true; // Mark as hit
            ApplicationData.NumHit++; // Update the app data
            LeftHandCatches++; // Increment left-hand catch count

            flying.SetActive(false); // Hide flying object
            caught.SetActive(true); // Show caught object
            OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.LTouch); // Start vibration
            Invoke("StopVibration", 0.1f); // Stop vibration after 0.1 seconds
            Invoke("DestroyCaughtBall", 3f); // Destroy caught ball after 3 seconds
        }
    }

    void DestroyCaughtBall()
    {
        this.gameObject.SetActive(false); // Disable the caught ball

        if (ApplicationData.NumShot >= ApplicationData.NumMax) // Is the game over? Last object caught?
        {
            Invoke("Endgame", 3f);
        }
    }

    void Endgame()
    {
        // Store the Right and Left hand scores in PlayerPrefs
        PlayerPrefs.SetInt("RightHandScore", RightHandCatches);
        PlayerPrefs.SetInt("LeftHandScore", LeftHandCatches);

        // Load the Endgame scene
        SceneManager.LoadScene("Workout_Endgame");
    }

    void StopVibration()
    {
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch); // Stop left-hand vibration
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch); // Stop right-hand vibration
    }
}