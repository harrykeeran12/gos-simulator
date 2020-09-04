using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using System.IO;
using SimpleJSON;
using System.Threading;

public class goslingBehaviour : MonoBehaviour

{
    private bool evaluation;
    private int no_gos;
    private int no_item;
    public int hours = 0;
    public bool criticalPeriod;
    public int temp = 0;
    private float startTime = 0;
    
    private void Awake()//called at load
    {
  
    }


    public class Gosling
    {
        public ArrayList gosling_position = new ArrayList(3);
        public ArrayList longest_item_looked_at = new ArrayList();
        public float time_spawned = 0;
        public bool criticalPeriod = false;
        
    }
     IEnumerator time()//ienumerators allow you to wait for a certain period of time 
    {
        yield return new WaitForSecondsRealtime(1);
    }

    void critical_period(int hours)
    {
        string path = Application.persistentDataPath + "/settings.json";
        string strtempSettings = File.ReadAllText(path);
        JSONObject settingsJSON = (JSONObject)JSON.Parse(strtempSettings);
        evaluation = settingsJSON["evaluation"];
        no_gos = settingsJSON["no_goslings"];
        no_item = settingsJSON["no_items"];
        if (evaluation == false)
        {
            int upper = 48;
            int lower = 24;
            if ((hours > lower) & (hours < upper))
            {
                criticalPeriod = true;
                Debug.Log("critical period is true");
                StartCoroutine(time());
                


            }
            else if (hours < 24)
            {
                Debug.Log("baby");
                StartCoroutine(time());
                


            }
            
        }
        else
        {
            int upper = 17;
            int lower = 12;
            if ((hours > lower) & (hours < upper))
            {
                criticalPeriod = true;
                Debug.Log("critical period is true");
                StartCoroutine(time());
                

            }
            else if(hours < 12)
            {
                Debug.Log("baby");
                StartCoroutine(time());
                

            }
        }
        StartCoroutine(time());


    }
   
    // Start is called before the first frame update
    void Start()
    {
        float startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - startTime;
        string minutes = ((int)t / 60).ToString();
        string seconds = ((int)t % 60).ToString();
        int hours = ((int)t / 60);
        critical_period(hours);

    }

}
