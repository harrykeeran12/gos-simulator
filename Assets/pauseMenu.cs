using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : EditorSceneManager
{
    public void loadSim()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("SimSaved"));
    }
    public void saveSim()
    {
        EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene(),"Assets/MyScenes/SimSaved.unity");
        PlayerPrefs.SetInt("SimSaved", SceneManager.GetActiveScene().buildIndex);
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
