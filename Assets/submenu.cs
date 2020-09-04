using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using System.IO;
using SimpleJSON;
using System.Threading;

public class submenu : MonoBehaviour
{
    public Transform gos;
    public GameObject spawnee;
    private int no_gos;
    private int no_item;
    public float counter;



    // Start is called before the first frame update
    void Start()
    {
        string path = Application.persistentDataPath + "/settings.json";
        string strtempSettings = File.ReadAllText(path);
        JSONObject settingsJSON = (JSONObject)JSON.Parse(strtempSettings);
        no_gos = settingsJSON["no_goslings"];
    }

    // Update is called once per frame
   void FixedUpdate()
    {
        if (counter < no_gos) 
        {
            if (Input.GetKeyDown("n"))//on click - will change
            {
                Instantiate(spawnee, new Vector3(0, 0, 0), gos.rotation);
                counter++;


            }
        }
       
        
    }
    void Destruction()
    {
        if (Input.GetKeyDown("l"))
        {
            Destroy(this.gameObject);
        }

    }
    void SpeedTime()
    {

    }
    void SlowTime()
    {

    }
    void PauseSim()
    {

    }
    void PlaySim()
    {

    }
    void helpButton()
    {

    }


}

