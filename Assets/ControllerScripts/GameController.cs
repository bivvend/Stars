using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public static GameController Control;

    public int NumShips = 1;
    public List<string> PlanetNames = new List<string>();

    public float BoardSizeX;
    public float BoardSizeY;
    public float PlanetZ;

    public float MinAsteroidDistance;
    public float MaxAsteroidDistance;

    public GameObject Earth;
    public GameObject Mars;
    public GameObject Pluto;

    public int NumAsteroids;

    public List<GameObject> AsteroidBelt;
    public GameObject Asteroid; //Asteroid prefab
    public GameObject Asteroid1; //Asteroid prefab
    public GameObject Asteroid2; //Asteroid prefab
    public GameObject Asteroid3; //Asteroid prefab
    public GameObject Asteroid4; //Asteroid prefab
    public GameObject Asteroid5; //Asteroid prefab

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
        //Define setup
        BoardSizeX = 4000.0f;
        BoardSizeY = 4000.0f;

        MinAsteroidDistance = 600.0f;
        MaxAsteroidDistance = 800.0f;

        NumAsteroids = 500;
        PlanetZ = 1.0f;

        //Store object references
        Earth = GameObject.Find("Earth");
        Mars = GameObject.Find("Mars");
        Pluto = GameObject.Find("Pluto");

        //GENERATE OBJECTS
        //Asteroids
        float r = 0.0f;
        float angle = 0.0f;
        float scale = 0.0f;
        foreach(int i in Enumerable.Range(0,NumAsteroids))
        {
            r = Random.Range(MinAsteroidDistance, MaxAsteroidDistance);
            angle = Random.Range(0, 360);
            scale = Random.Range(2.0f, 5.0f);
            int type = (int)(Random.Range(0, 6.0f));
            GameObject newAsteroid;
            switch(type)
            {
                case 0:
                    newAsteroid = Instantiate(Asteroid);
                    break;
                case 1:
                    newAsteroid = Instantiate(Asteroid1);
                    break;
                case 2:
                    newAsteroid = Instantiate(Asteroid2);
                    break;
                case 3:
                    newAsteroid = Instantiate(Asteroid3);
                    break;
                case 4:
                    newAsteroid = Instantiate(Asteroid4);
                    break;
                case 5:
                    newAsteroid = Instantiate(Asteroid5);
                    break;
                default:
                    newAsteroid = Instantiate(Asteroid);
                    break;


            }

            
            newAsteroid.transform.localScale = new Vector3(scale, scale, 1.0f);
            ObjectRotate rotateScript = newAsteroid.GetComponent<ObjectRotate>();
            rotateScript.OrbitRadius = r;
            rotateScript.OrbitalPeriod = 10000.0f + r * 5.0f;
            rotateScript.AngleDegs = angle;
            rotateScript.SpinRate = Random.Range(-0.5f, 0.5f);
            AsteroidBelt.Add(newAsteroid);
        }
    }

    void OnGUI()
    {

        GUI.Label(new Rect(10, 10, 100, 30), "Number of Ships: " + NumShips); 
    }

}
