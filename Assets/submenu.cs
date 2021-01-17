using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using SimpleJSON;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class subMenu : MonoBehaviour {
    public Transform gos; //this variable is required for the instantiation of the gosling. 
    public GameObject spawnee; //this is the placement of where the object is.
    public GameObject item; //this is the first item that is instantiated from
    public GameObject gosling; // this is the first gosling that is to be instantiated from.
    private int no_gos; //this is a temporary variable that is taken from the settings.json file.
    private int no_item; //this is another temporary variable that is taken from the settings.json file.
    private bool evaluation; //the temporary variable that is taken from the settings.json file.
    private int item_number; //this is the amount of items in the scene right now.     
    public int counter; //this is the amount of goslings in the scene currently.
    public float timescale = 0f; //this is a temporary value for the timescale. This is changed by pressing the speed up + slow down buttons.
    public Camera gameCamera; //this is required so that the destruction method works.
    public static bool isPaused; //this pauses the simulation.
    private float temptimeScale; //this stores the variable before the simulation has been sped up.
    public GameObject pauseMenu; //this is required so that the pausemenu can be enabled and disabled.
    public GameObject pauseButton;//this is required to turn off and on the pause button.
    public GameObject playButton;//this is also required to turn the play button on from behind the pause button.
    public Text multiplier; //this is the text value that changes
    public float x; //this is saved as the new time scale
    public ArrayList helpstatements = new ArrayList (3); //list of the help button statements.

    // Start is called before the first frame update
    void Start () {
        string path = Application.persistentDataPath + "/settings.json";
        string strtempSettings = File.ReadAllText (path);
        JSONObject settingsJSON = (JSONObject) JSON.Parse (strtempSettings);
        no_gos = settingsJSON["no_goslings"];
        no_item = settingsJSON["no_item"];
        evaluation = settingsJSON["evaluation"];
        //loads the no_gos settings, no_items, and evaluation from the settings.json file.
    }

    public void newClone () //instantiates the gosling
    {

        if (counter <= no_gos) {
            Instantiate (gosling, new Vector3 (0, 0, 0), gos.rotation);
            counter++;

        }
    }
    void newItem () //instantiates the item
    {

        if (item_number <= no_item) {
            Instantiate (item, new Vector3 (0, 0, 0), gos.rotation);
            item_number++;

        }
    }
    void Destruction () //this method destroys the game object at a click.
    {

        Ray ray = gameCamera.ScreenPointToRay (Input.mousePosition);
        RaycastHit hitInfo;

        if ((Physics.Raycast (ray, out hitInfo)) && (Input.GetKeyDown ("1"))) {

            Destroy (hitInfo.collider.gameObject);
        }

        if (Input.GetKeyDown ("l")) {
            Destroy (this.gameObject);
        }

    }
    public void SpeedTime () //speeds up the timescale.
    {
        Time.timeScale = timescale + 1;
        //need to do an button to increase the time
        x = Time.timeScale;
        timescale = Time.timeScale;
        multiplier.text = ("Multiplier:" + x.ToString ());

    }
    public void SlowTime () //slows down the timescale.
    {
        Time.timeScale = timescale - 1;
        //need to decrease the time + have a button
        x = Time.timeScale;
        timescale = Time.timeScale;
        multiplier.text = ("Multiplier:" + x.ToString ());
    }
    public void PauseSim () //turns on the pause menu + pauses the simulation
    {
        isPaused = true;
        if (isPaused) {
            temptimeScale = Time.timeScale;
            Time.timeScale = 0f;
            pauseMenu.SetActive (true);
            pauseButton.SetActive (false);
            playButton.SetActive(true);
            //the canvas can change at this point + i can add the save button functions in the inspector.
        }
    }
    public void PlaySim () {
        isPaused = false;
        pauseMenu.SetActive (false);
        pauseButton.SetActive (true);
        playButton.SetActive(false);
        Time.timeScale = temptimeScale;
        //this can be the same button as the pause menu- it will turn off the pause menu
    }
    public void helpButton (Text message, ArrayList helpstatements) {
        helpstatements.Add ("The evaluation is currently true. Hess thought that goslings imprinted in a much shorter timeframe, around 12 to 17 hours.");

        helpstatements.Add ("A gosling's critical period is the time at which imprinting is most likely to take place.");

        helpstatements.Add ("The evaluation mode is currently false");

        if (pauseMenu.activeSelf == false) {
            if (evaluation == true) {
                message.text = helpstatements[0].ToString ();
            } else if (goslingBehaviour.criticalPeriod == true) {
                message.text = helpstatements[1].ToString ();
            } else {
                message.text = helpstatements[2].ToString ();
            }

        }
        //displays help button if a specific thing is true. 
    }
    public void loadSim () //loads simulation
    {
        SceneManager.LoadScene (PlayerPrefs.GetInt ("SimSaved"));
    }
    public void saveSim () //saves simulation
    {
        PlayerPrefs.SetInt ("SimSaved", SceneManager.GetActiveScene ().buildIndex);
    }

}