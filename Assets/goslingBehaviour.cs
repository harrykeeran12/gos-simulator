using System.Collections;
using UnityEngine;
using System.IO;
using SimpleJSON;

public class goslingBehaviour : MonoBehaviour



{
    public float rayLength = 500f;
    private bool evaluation;
    public int hours = 0;
    public bool criticalPeriod;
    public int temp = 0;
    private float startTime = 0;
    
    public LayerMask mask;
    public Gosling gos;


    
    
     public class Gosling
    {
        //public ArrayList gosling_position = new ArrayList(3); //don't need this any more because of new savesystem 
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
   
    
     void rayCast(Gosling){
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit; 
        if (Physics.Raycast (ray, out hit, rayLength, mask)){
            if((hit.collider.gameObject.name == "Capsule")) //&(criticalPeriod == true)) <-- add this back in later
            {

                Debug.DrawLine(ray.origin, hit.point, Color.blue);
                gos.longest_item_looked_at.Add(hit.collider.gameObject.name.ToString()); //<- does not work for some reason
                gos.longest_item_looked_at.Add(Time.unscaledTime - hours);
                

                


            }

            else{
                Debug.DrawLine(ray.origin, ray.origin + ray.direction * rayLength, Color.green);
            }
       }
        }
     
    
    // Start is called before the first frame update
    void Start()
    {
        float startTime = Time.time;
        

    }

    // Update is called once per frame
    void FixedUpdate() //my game loop
    {
        float t = Time.time - startTime;
        string minutes = ((int)t / 60).ToString();
        string seconds = ((int)t % 60).ToString();
        int hours = ((int)t / 60);
         //all of the above gets the time that has passed
        //Debug.Log(hours);
        critical_period(hours);
        rayCast(gos);

    }

}
