using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour {
    
     public void saveSim()
    {
        PlayerPrefs.SetInt("SimSaved", SceneManager.GetActiveScene().buildIndex); //use player prefs to save values between scenes and load them.
    }
    public void loadSim()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("SimSaved")); // loads the exact build index of the scene
    }
   
}
