using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UserInputControl : MonoBehaviour
{
    public float Sensitivity; 
    public float ZMin;
    public float ZMax;

    public float MoveStep;
    
    // Start is called before the first frame update

    void Start()
    {
        Sensitivity = 100.0f;
        ZMin = -10000.0f;
        ZMax = 2;
        MoveStep = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if(Camera.current !=null)
        {
            float zDist = Input.GetAxis("Mouse ScrollWheel") * Sensitivity;
            var cam = Camera.current;
            float zPos = cam.transform.position.z;
            float newPos = zPos + zDist;
            Debug.Log(newPos);
            Debug.Log(ZMax);
            if(newPos > ZMax || newPos < ZMin)
            {
            }
            else
            {
                cam.transform.Translate(0.0f, 0.0f, zDist);
            }

            if (Input.GetKey("up"))
            {
                cam.transform.Translate(0.0f, MoveStep, 0.0f);
            }

            if (Input.GetKey("down"))
            {
                cam.transform.Translate(0.0f, -1 * MoveStep, 0.0f);
            }

            if (Input.GetKey("left"))
            {
                cam.transform.Translate(MoveStep, 0.0f, 0.0f);
            }

            if (Input.GetKey("right"))
            {
                cam.transform.Translate(-1 * MoveStep, 0.0f, 0.0f);
            }

                

        }        
      
    }
}
