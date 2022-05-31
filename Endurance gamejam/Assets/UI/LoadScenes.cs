using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{


    [HideInInspector]public float steerSensitivity;

    [HideInInspector]public Slider steerSlider;

    public GameObject scoreManager;

    private bool stop;

    public GameObject bike;
    private BikeAcceleration bikeAccel;

    private static bool lost;

    private void Awake()
    {
        bikeAccel = bike.GetComponent<BikeAcceleration>();
        bikeAccel.stop = false;
        lost = false;
        //steerSensitivity = GetComponent<BikeSteering>().steeringPower;
        //PlayerPrefs.SetFloat("Speed", steerSensitivity);
        //steerSlider.value = steerSensitivity;
    }

    private void Update()
    {
        Lose();
    }

    public void Play()
    {
            
      SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);  
        
    }

    public void Exit()
    {
        Application.Quit();
    }

    private void Lose()
    {
        Scene scene = SceneManager.GetActiveScene();
        string sceneName = scene.name;

        if (sceneName == "GameOver")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Play();
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }

        }

        if(sceneName == "MainMenu")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Play();
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }

        if (bikeAccel.stop)
        {
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
           
        }
    }


}
