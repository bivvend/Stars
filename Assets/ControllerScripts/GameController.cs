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

    void OnGUI()
    {

        GUI.Label(new Rect(10, 10, 100, 30), "Number of Ships: " + NumShips); 
    }

}
