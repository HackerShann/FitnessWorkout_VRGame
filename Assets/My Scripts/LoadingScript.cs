using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Workout_Main");
        //in the background
    }

}
