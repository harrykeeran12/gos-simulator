using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public void NewSimulation()
    {
        Debug.Log("Starting New Simulation...");
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);

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
    }

    
}

