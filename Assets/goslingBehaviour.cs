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
    public int hours = 0;
    public bool criticalPeriod;
    public int temp = 0;
    private float startTime = 0;
    
     public class Gosling
    {
        public ArrayList gosling_position = new ArrayList(3); //don't need this any more because of new savesystem 
        //- i don't need to save the position of the elements.
        public ArrayList longest_item_looked_at = new ArrayList();
        public float time_spawned = 0;
        public bool criticalPeriod = false;
        
    }
     IEnumerator time()//ienumerators allow you to wait for a certain period of time -> this method of waiting for time does not work
    {
        yield return new WaitForSecondsRealtime(1);
    }

    void critical_period(int hours)
    {
        string path = Application.persistentDataPath + "/settings.json";
        string strtempSettings = File.ReadAllText(path);
        JSONObject settingsJSON = (JSONObject)JSON.Parse(strtempSettings);
        evaluation = settingsJSON["evaluation"];
        if (evaluation == false)
        {
            int upper = 48;
            int lower = 24;
            if ((hours > lower) & (hours < upper))
            {
                criticalPeriod = true;
                Debug.Log("critical period is true");
                StartCoroutine(time());//-> take this out
                


            }
            else if (hours < 24)
            {
                
                StartCoroutine(time());//-> take this out



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
                StartCoroutine(time());//-> take this out


            }
            else if(hours < 12)
            {
                StartCoroutine(time());//-> take this out


            }
        }
        StartCoroutine(time());//-> take this out


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
        Debug.Log(hours);
        critical_period(hours);

    }

}
