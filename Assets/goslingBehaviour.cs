using System.Collections;
using System.IO;
using SimpleJSON;
using UnityEngine;

public class goslingBehaviour : MonoBehaviour

{
    public float rayLength = 500f;
    private bool evaluation;
    public int hours = 0;
    public bool criticalPeriod;
    public int temp = 0;
    private float startTime = 0;
    public LayerMask mask;
    //public Gosling duck;

    //public class Gosling : goslingBehaviour {
        //public ArrayList gosling_position = new ArrayList(3); //don't need this any more because of new savesystem 
        //- i don't need to save the position of the elements.
        public ArrayList longest_item_looked_at = new ArrayList ();
        public float time_spawned;
        
        public void critical_period (int hours) {
            string path = Application.persistentDataPath + "/settings.json"; //reads the path of the settings file
            string strtempSettings = File.ReadAllText (path); //opens file
            JSONObject settingsJSON = (JSONObject) JSON.Parse (strtempSettings); //changes json file to c# readable file
            evaluation = settingsJSON["evaluation"]; //assigns evaluation to the evaluation value in the settings file
            if (evaluation == false) {
                int upper = 48;
                int lower = 24;
                if ((hours > lower) & (hours < upper)) {
                    criticalPeriod = true;
                    //evaluates the critical period

                } 
                else if (hours < 24) {
                    
                }

            } 
            else {
                int upper = 17;
                int lower = 12;
                if ((hours > lower) & (hours < upper)) {
                    criticalPeriod = true;
                    //changes the critical period of the gosling

                }
            }
            

        }

        public void rayCast () {
            Ray ray = new Ray (transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast (ray, out hit, rayLength, mask)) {
                if ((hit.collider.gameObject.name == "Capsule")) //&(criticalPeriod == true)) <-- add this back in later
                {
                    Debug.DrawLine (ray.origin, hit.point, Color.blue);
                    

                } 
                else {
                    Debug.DrawLine (ray.origin, ray.origin + ray.direction * rayLength, Color.green);
                }
            }
        }
    


    // Start is called before the first frame update
    void Start () {
        float startTime = Time.time;
    }

    // Update is called once per frame
    void FixedUpdate () //my game loop
    {
        float t = Time.time - startTime;
        string minutes = ((int) t / 60).ToString ();
        string seconds = ((int) t % 60).ToString ();
        int hours = ((int) t / 60);
        //all of the above gets the time that has passed
        //Debug.Log(hours);
        critical_period(hours);
        rayCast();
    }
}

