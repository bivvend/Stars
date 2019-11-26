using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public static GameController Control;

    public int NumShips = 1;
    public List<string> PlanetNames = new List<string>();

    public float EarthDist;
    public float MoonEarthDistance;    
    public float MarsDistance;
    public float PlutoDistance;
    public float BoardSizeX;
    public float BoardSizeY;
    public float PlanetZ;

    public GameObject Earth;
    public GameObject Mars;
    public GameObject Pluto;

    void Awake()
    {
        if(Control == null)
        {
            DontDestroyOnLoad(gameObject);
            Control = this;

        }
        else if(Control != this)
        {
            Destroy(gameObject);
            
        }        
    }

    void Start()
    {
        SetupBoard();
    }

    void SetupBoard()
    {
        BoardSizeX = 4000.0f;
        BoardSizeY = 4000.0f;

        EarthDist = 0.107f;
        MarsDistance = 0.165f;
        PlutoDistance = 0.95f;

        PlanetZ = 1.0f;

        Earth = GameObject.Find("Earth");
        Mars = GameObject.Find("Mars");
        Pluto = GameObject.Find("Pluto");

        Earth.transform.position = new Vector3(EarthDist * BoardSizeX / 2.0f, 0, PlanetZ);
        Mars.transform.position = new Vector3(0, MarsDistance * BoardSizeY / 2.0f, PlanetZ);
        Pluto.transform.position = new Vector3(PlutoDistance * BoardSizeX / 2.0f, 0, PlanetZ);
    }

    void OnGUI()
    {

        GUI.Label(new Rect(10, 10, 100, 30), "Number of Ships: " + NumShips); 
    }

}
