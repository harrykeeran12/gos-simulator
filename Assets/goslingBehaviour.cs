using System.Collections;
using System.IO;
using SimpleJSON;
using UnityEngine;

public class goslingBehaviour : MonoBehaviour

{
    public float rayLength = 500f; //the ray length that is outputted by the gosling
    private bool evaluation; //a temporary variable for the critical period function
    public int hours = 0; //starting value for the hours variable, resets it each time a new gosling is spawned.
    public static bool criticalPeriod;
    private float startTime = 0; //temporary variable for the start time of the gosling
    public LayerMask mask; //this mask detects if the gosling hits a item with the raycast. 

    public void critical_period (int hours) { //this method changes the critical period value 
        string path = Application.persistentDataPath + "/settings.json"; //reads the path of the settings file
        string strtempSettings = File.ReadAllText (path); //opens file
        JSONObject settingsJSON = (JSONObject) JSON.Parse (strtempSettings); //changes json file to c# readable file
        evaluation = settingsJSON["evaluation"]; //assigns evaluation to the evaluation value in the settings file
        if (evaluation == false) {
            int upper = 48;
            int lower = 24;
            if ((hours > lower) & (hours < upper)) {
                criticalPeriod = true;
                Debug.Log ("Critical Period is now true.");
                //evaluates the critical period

            } else if (hours < 24) {

            }

        } else {
            int upper = 17;
            int lower = 12;
            if ((hours > lower) & (hours < upper)) {
                criticalPeriod = true;
                //changes the critical period of the gosling

            }
        }

    }

    public void rayCast () { //a ray is emitted to detect the position of the gosling 
        Ray ray = new Ray (transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast (ray, out hit, rayLength, mask)) {
            if ((hit.collider.gameObject.name == "Capsule") && (criticalPeriod == true)) {
                Debug.DrawLine (ray.origin, hit.point, Color.blue);

            } else {
                Debug.DrawLine (ray.origin, ray.origin + ray.direction * rayLength, Color.green);
            }
        }
    }

    void Start () {
        float startTime = Time.time; //saves the time of spawn as current time.
        Debug.Log (evaluation);
        Debug.Log (criticalPeriod);
    }

    // Update is called once per frame
    void FixedUpdate () //this is the main game loop 
    {
        float t = Time.time - startTime;
        string minutes = ((int) t / 60).ToString ();
        string seconds = ((int) t % 60).ToString ();
        int hours = ((int) t / 60);
        //all of the above gets the time that has passed since creation.
        critical_period (hours);
        rayCast ();
    }
}