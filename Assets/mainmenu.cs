using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public void NewSimulation()
    {
        Debug.Log("Starting New Simulation...");
        SceneManager.LoadScene(1);

    }
    
    
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    public void LoadSimulation()
    {
        Debug.Log("Loaded Simulation");
        Debug.Log("Simulation has been loaded");
        SceneManager.LoadScene(PlayerPrefs.GetInt("SimSaved"));//changed from build next one to building the new simulation
    }

    
}

