using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

[ExecuteAlways]
public class LightingManager : MonoBehaviour
{
    //Scene References
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private LightingPreset Preset;
    //Variables
    [SerializeField, Range(0, 24)] public float TimeOfDay;

    private bool bank;
    private bool buyBall;
    private bool groceries;
    private bool vistGF;

    private bool allTasksDone;
    private bool bed;

    private bool Activebank;
    private bool ActivebuyBall;
    private bool Activegroceries;
    private bool ActivevistGF;
   
    private bool Activebed;

    private bool Curfew;

    private bool GameOver;

    public GameObject Check_Obj_bank;
    public GameObject Check_Obj_buyBall;
    public GameObject Check_Obj_groceries;
    public GameObject Check_Obj_vistGF;
    public GameObject Check_Obj_bed;
    public GameObject Check_Obj_Cop;
    public GameObject Check_Obj_NPC;

    public GameObject CutS1;
    public GameObject CutS2;
    public GameObject CutS3;
    public GameObject CutS4;
    public GameObject Ball;
    public GameObject BallTP;

    VideoPlayer Vid1;
    VideoPlayer Vid2;
    VideoPlayer Vid3;
    VideoPlayer Vid4;

    public GameObject UITimeOfDay;
    Text TimeOfDayDisplay;

    void Start()
    {
       GameOver = false;
       bank = false;
        buyBall = false;
        groceries = false;
        vistGF = false;
        allTasksDone = false;
        bed = false;

        Vid1 = CutS1.GetComponent<VideoPlayer>();
        Vid2 = CutS2.GetComponent<VideoPlayer>();
        Vid3 = CutS3.GetComponent<VideoPlayer>();
        Vid4 = CutS4.GetComponent<VideoPlayer>();

        Vid1.enabled = false;
        Vid2.enabled = false;
        Vid3.enabled = false;
        Vid4.enabled = false;

       TimeOfDayDisplay = UITimeOfDay.GetComponent<Text>();

    }

    private void Update()
    {
        if (Preset == null)
            return;

        if (Application.isPlaying)
        {
            //(Replace with a reference to the game time)
            
            TimeOfDay += Time.deltaTime/45; // gets slower when you diveied 45 
            TimeOfDay %= 24; //Modulus to ensure always between 0-24
            UpdateLighting(TimeOfDay / 24f);
        }
        else
        {
            UpdateLighting(TimeOfDay / 24f);
        }
        
        
    }


    private void UpdateLighting(float timePercent)
    {
        //Set ambient and fog
        RenderSettings.ambientLight = Preset.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = Preset.FogColor.Evaluate(timePercent);

        //If the directional light is set then rotate and set it's color, I actually rarely use the rotation because it casts tall shadows unless you clamp the value
        if (DirectionalLight != null)
        {
            DirectionalLight.color = Preset.DirectionalColor.Evaluate(timePercent);

            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0));
        }

    }

    //Try to find a directional light to use if we haven't set one
    private void OnValidate()
    {
        if (DirectionalLight != null)
            return;

        //Search for lighting tab sun
        if (RenderSettings.sun != null)
        {
            DirectionalLight = RenderSettings.sun;
        }
        //Search scene for light that fits criteria (directional)
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach (Light light in lights)
            {
                if (light.type == LightType.Directional)
                {
                    DirectionalLight = light;
                    return;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        activeEvents();
        activeCurfur();
        endingRank();
        
        TimeOfDayDisplay.text = "Hour " + TimeOfDay.ToString();
    }


    void OnTriggerEnter(Collider other)
    {

        // Checks if the user goes to the bank
        if (other.gameObject == Check_Obj_bank)
        {
            if (bank == false && Activebank == true)
            {
                Vid1.enabled = true;
                //TimeOfDay ++;
                Debug.Log("You have gone to the bank");
                bank = true;    
            }
        }

        //Not working
        // Checks if the user goes to HamMart to buy the ball
        if (other.gameObject == Check_Obj_buyBall)
        {

            if (buyBall == false) 
            {
                if (bank == true && ActivebuyBall == true)
                {
                    //   TimeOfDay++;
                    Vid2.enabled = true;
                    Ball.transform.position = BallTP.transform.position;
                    Debug.Log("You bought the ball!");
                    buyBall = true;
                }
            }
        }

        // Checks if the user goes to the bank
        if (other.gameObject == Check_Obj_groceries)
        {
            if (groceries == false)
            {
                if (bank == true && Activegroceries == true)
                {

                    //TimeOfDay++;
                    Vid3.enabled = true;
                    Debug.Log("You got groceries!");
                    groceries = true;
                }
            }
        }

        // Checks if the user goes to the bank
        if (other.gameObject == Check_Obj_vistGF)
        {
            if (vistGF == false) 
            {
                if (ActivevistGF == true)
                {

                    //  TimeOfDay++;
                    Vid4.enabled = true;
                    Debug.Log("You visted your GF");
                    vistGF = true;
                }
            }
            
        }

        if (other.gameObject == Check_Obj_bed)
        {
            if (bed == false && Activebed == true)
            {
                Debug.Log("Day 1 is over");
            }
        }

        //////////////////////////////Game Overs/////////////////////////////

        //Rank D-:Breaking the law by being caught by one of the Police officers.
        if (other.gameObject == Check_Obj_Cop)
        {
            Debug.Log("Ending Rank: D-");
            Debug.Log("Cop!");
            GameOver = true;
        }
        // Rank D:When you get too close to an NPC without your hamster ball after the rule is enforced on day two.

        if (other.gameObject == Check_Obj_NPC)
        {
            Debug.Log("Ending Rank: D");
            Debug.Log("NPC!");
            GameOver = true;
        }


    }



    void activeEvents()
    {
        //Time where the bank is active
        if(TimeOfDay >= 6 && TimeOfDay <= 15 && bank == false)
        {
            Activebank = true;
            Debug.Log("The Bank is Open");
        }

        //Time where the HamMart is active
        if (TimeOfDay >= 9 && TimeOfDay <= 15 && buyBall == false)
        {
            ActivebuyBall = true;
            Debug.Log("The HamMart is Open");
        }
        else
        {
            Debug.Log("The HamMart is clsoed");
        }

        //Time where the Visting your GF is active
        if (TimeOfDay >= 10 && TimeOfDay <= 15 && vistGF == false)
        {
            ActivevistGF = true;
            Debug.Log("The GF is home");
        }

        //Time where the Groceries is active
        if (TimeOfDay >= 9 && TimeOfDay <= 15 && groceries == false)
        {
            Activegroceries= true;
            Debug.Log("The Grocerie store is Open");
        }

        // Lets the code now that all day 1 tasks are compete
        if (bank == true && buyBall == true && vistGF == true && groceries == true)
        {
            allTasksDone = true;
            Debug.Log("All taskes are done");
        }

        //Time where the Bed  is active
        if (TimeOfDay <= 15 && allTasksDone == true && bed == false)
        {
            Activebed = true;
            Debug.Log("The bed is active");
        }
    }

    void activeCurfur()
    {
        if (TimeOfDay >= 19)
        {
            Debug.Log("Curfew started");
            Curfew = true;
        }
        else 
        {
            Debug.Log("Curfew Not started yet");
            Curfew = false; 
        }
    }


    void endingRank()
    {
        //Rank E: Falling to go to bed in time on the first day.
        if (TimeOfDay >= 23 && bed == false)
        {
            Debug.Log("Ending Rank: E");
            GameOver = true;
        }
 
        //Rank F: Failing to complete any of the tasks on the first day.
        if (TimeOfDay >= 15 && bank == false || TimeOfDay >= 15 && groceries == false || TimeOfDay >= 15 && vistGF == false)
        {
            Debug.Log("Ending Rank: F");
            GameOver = true;
        }
    }






}