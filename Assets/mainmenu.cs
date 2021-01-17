using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//all of these with the key word using are the namespaces that i have used in this section of my code.

public class mainMenu : MonoBehaviour {
    public void NewSimulation () {
        Debug.Log ("Starting New Simulation..."); //this is a temporary output to signal that the program has loaded.
        SceneManager.LoadScene (1); //this loads the next scene.

    }

    public void QuitGame () {
        Debug.Log ("Quit"); //this is another temporary output
        Application.Quit (); //this exits out of the application.
    }
    public void LoadSimulation () {
        Debug.Log ("Loaded Simulation");
        Debug.Log ("Simulation has been loaded"); //these both are more temporary outputs.
        if (SceneManager.sceneCountInBuildSettings == 2){
            SceneManager.LoadScene (2); //changed from build next one to building the saved simulation
        }
        else{
            
        }
        
    }

}