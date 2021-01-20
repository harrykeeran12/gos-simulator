using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
public class pauseMenu : MonoBehaviour {

    public GameObject PauseMenu;
        
    public void saveSim()
    {
       EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene(), "/SimSaved.unity", true); //cannot be used during play mode.

    }
    public void loadSim()
    {
     /*    EditorSceneManager.LoadSceneInPlayMode("/SimSaved",  LoadSceneMode.Additive);  */
        
    }
    public void Quit(){
       Application.Quit ();
    }
}
   

