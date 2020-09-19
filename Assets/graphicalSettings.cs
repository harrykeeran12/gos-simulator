using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using SimpleJSON;



public class graphicalSettings : MonoBehaviour
{
    public Text score;
    public Text score2;
    public ArrayList temp_settings = new ArrayList(3);
    public bool evaluation = false;
    public int no_gos = 0;
    public int no_item = 0;

    public void blank()
    {
        temp_settings.Insert(0, false); //got null reference because of these values == null <=
        temp_settings.Insert(1, "3");
        temp_settings.Insert(2, "1");

    }//creates a list that temporarily stores 3 variables which can be later overwritten

    public void evaluationmode(bool evaluate)
    {
        if (evaluate == true)
        {
            Debug.Log("Evaluation Mode = True");
            temp_settings.Insert(0, evaluate.ToString());
            Debug.Log("");
        }
        else
        {
            Debug.Log("Evaluation Mode = False");
            temp_settings.Insert(0, evaluate.ToString());
        }

    }
       
    
    public void no_of_goslings(float no_gosling)
    {
        score.text = no_gosling.ToString();
        temp_settings.Insert(1,score.text);


    }
    public void no_of_items(float items)
    {
        score2.text = items.ToString();
        temp_settings.Insert(2, score2.text);
        

    }
   
     private void Start()
        {
            Debug.Log(temp_settings.ToString());//outputs to log
        }
     public void SaveSettings()
    {
        string path = Application.persistentDataPath + "/settings.json";
        if (File.Exists(path))
        {
        JSONObject settingsJSON = new JSONObject();//creates new json object for placing file in
        settingsJSON.Add("evaluation", temp_settings[0].ToString());
        settingsJSON.Add("no_goslings", temp_settings[1].ToString());
        settingsJSON.Add("no_items", temp_settings[2].ToString());
        
        File.WriteAllText(path, settingsJSON.ToString());//writes to the file
        //saves file to %appdata%/locallow/DefaultCompany/gos sim/settings.json
        }
        else
        {
            File.Create(path);
            JSONObject settingsJSON = new JSONObject();//creates new json object for placing file in
            settingsJSON.Add("evaluation", temp_settings[0].ToString());
            settingsJSON.Add("no_goslings", temp_settings[1].ToString());
            settingsJSON.Add("no_items", temp_settings[2].ToString());
//adds to file
            File.WriteAllText(path, settingsJSON.ToString());

        }
        

             
     
    } 
    
    public void LoadSettings()
    {
        string path = Application.persistentDataPath + "/settings.json";
        string strtempSettings = File.ReadAllText(path);
        JSONObject settingsJSON = (JSONObject)JSON.Parse(strtempSettings);
        evaluation = settingsJSON["evaluation"];
        no_gos = settingsJSON["no_goslings"];
        no_item = settingsJSON["no_items"];





    }




}

