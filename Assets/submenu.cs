﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using System.IO;
using SimpleJSON;
using System.Threading;
using UnityEngine.SceneManagement;

public class subMenu : MonoBehaviour
{
    public Transform gos;
    public GameObject spawnee;
    public GameObject item;
    private int no_gos;
    private int no_item;
    private int item_number;
    public float counter;
    public float timescale = 0f;
    public Camera gameCamera;
    public bool isPaused;
    private float temp_timescale;
    public GameObject pauseMenu;
    public Text multiplier;
    public float x;



    // Start is called before the first frame update
    void Start()
    {
        string path = Application.persistentDataPath + "/settings.json";
        string strtempSettings = File.ReadAllText(path);
        JSONObject settingsJSON = (JSONObject)JSON.Parse(strtempSettings);
        no_gos = settingsJSON["no_goslings"];
        no_item = settingsJSON["no_item"];
        //loads the no_gos settings and no_items
    }

    // Update is called once per frame
   void FixedUpdate(){
        newClone();
       
        
    }
    void newClone()
    {
        if (counter <= no_gos)
        {
            if (Input.GetKeyDown("n"))//on click - will change
            {
                Instantiate(spawnee, new Vector3(0, 0, 0), gos.rotation);
                counter++;


            }
        }
    }
    void newItem()
    {
        if (item_number <= no_item)
        {
            if (Input.GetKeyDown("k"))//this is also temporary
            {
                Instantiate(item, new Vector3(0, 0, 0), gos.rotation);
                item_number++;
            }
            

        }
    }
    void Destruction()
    {

      Ray ray = gameCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if((Physics.Raycast(ray, out hitInfo))&&(Input.GetKeyDown("1"))) {
            Destroy(hitInfo.collider.gameObject);
        }

        
        if (Input.GetKeyDown("l"))
        {
            Destroy(this.gameObject);
        }

    }
    public void SpeedTime()
    {
        Time.timeScale = timescale + 1;
        //need to do an button to increase the time
        x = Time.timeScale;
        timescale = Time.timeScale;
        multiplier.text = ("Multiplier:" + x.ToString());



    }
    public void SlowTime()
    {
        Time.timeScale = timescale - 1;
        //need to decrease the time + have a button
        x = Time.timeScale;
        timescale = Time.timeScale;
        multiplier.text = ("Multiplier:" + x.ToString());
    }
    public void PauseSim(GameObject PauseMenu)
    {
        isPaused = true;
        if (isPaused)
        {
            temp_timescale = Time.timeScale;
            PauseMenu.SetActive(true);
            //the canvas can change at this point + i can add the save button functions in the inspector.
        }
    }
    public void PlaySim(GameObject PauseMenu)
    {
        isPaused = false;
        PauseMenu.SetActive(false);
        //this can be the same button as the pause menu- it will allow me to change the canvas back to normal , and turn off the pause menu
    }
    void helpButton()
    {

       //switch here
        //this button needs to actually make sense - needs to know what is happening on screen + explain stuff properly. 
    }
    void loadSim()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("SimSaved"));
    }
    void saveSim()
    {
        PlayerPrefs.SetInt("SimSaved", SceneManager.GetActiveScene().buildIndex);
    }
    

}

