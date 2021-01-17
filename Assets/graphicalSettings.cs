using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using JetBrains.Annotations;
using SimpleJSON;
using UnityEngine;
using UnityEngine.UI;

public class graphicalSettings : MonoBehaviour {
    public GameObject UI;
    public Text score;
    public Text score2;
    public ArrayList temp_settings = new ArrayList (3);
    public bool evaluation = false;
    public int no_gos = 0;
    public int no_item = 0;
    public Slider slider1;
    public Slider slider2;
    public Toggle evaluatebox;
    //public GameObject slider1;
    //public GameObject slider2;

    public void blank () {
        temp_settings.Insert (0, false); //got null reference because of these values == null <=
        temp_settings.Insert (1, "3");
        temp_settings.Insert (2, "2");

    } //creates a list that temporarily stores 3 variables which can be later overwritten

    public void evaluationmode (bool evaluate) //this checks the evaluation mode and if it works properly or not.
    {
        if (evaluate == true) {
            Debug.Log ("Evaluation Mode = True");
            temp_settings.Insert (0, evaluatebox.isOn.ToString ());
            Debug.Log ("");
        } else {
            Debug.Log ("Evaluation Mode = False");
            temp_settings.Insert (0, evaluatebox.isOn.ToString ());
        }
//FIX THIS
    }

    public void no_of_goslings (float no_gosling) //adds the gosling number to the settings.json file
    {
        score.text = no_gosling.ToString ();
        Debug.Log (no_gosling);
        temp_settings.Insert (1, no_gosling);
    }
    public void no_of_items (float items) //adds the max item number to the settings.json file
    {
        score2.text = items.ToString ();
        Debug.Log (items);
        temp_settings.Insert (2, items);
    }

    void Start () {
        Debug.Log (temp_settings.ToString ()); //outputs to log
        blank ();
    }
    public void SaveSettings () //saves the settings into the json file
    {
        string path = Application.persistentDataPath + "/settings.json";
        JSONObject settingsJSON = new JSONObject (); //creates new json object for placing file in
        settingsJSON.Add ("evaluation", temp_settings[0].ToString ());
        settingsJSON.Add ("no_goslings", temp_settings[1].ToString ());
        settingsJSON.Add ("no_items", temp_settings[2].ToString ());
        File.WriteAllText (path, settingsJSON.ToString ()); //writes to the file
        //saves file to %appdata%/locallow/DefaultCompany/gos sim/settings.json
        Debug.Log (temp_settings);
    }

    public void LoadSettings () //loads settings into programs. 
    {
        string path = Application.persistentDataPath + "/settings.json";
        string strtempSettings = File.ReadAllText (path);
        JSONObject settingsJSON = (JSONObject) JSON.Parse (strtempSettings);
        evaluation = settingsJSON["evaluation"];
        no_gos = settingsJSON["no_goslings"];
        no_item = settingsJSON["no_items"];
        evaluation = evaluatebox.isOn;
        score.text = no_gos.ToString();
        score2.text = no_item.ToString();
        slider1.value = no_gos;
        slider2.value = no_item;
    }
    public void ResetGrap () {

        UI.gameObject.SetActive (false);
        score.text = 3. ToString ();
        score2.text = 2. ToString ();
        slider1.value = 3;
        slider2.value = 2;
        evaluatebox.isOn = false; 


    }

}