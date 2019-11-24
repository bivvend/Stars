using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UserInputControl : MonoBehaviour
{
    public float Sensitivity; 
    public float ZMin;
    public float ZMax;
    
    // Start is called before the first frame update

    void Start()
    {
        Sensitivity = 100.0f;
        ZMin = -10000.0f;
        ZMax = 2;
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

                

        }        
      
    }
}
