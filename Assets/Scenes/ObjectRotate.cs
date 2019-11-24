using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotate : MonoBehaviour
{
    // Start is called before the first frame update

    public float Angle;
    public float SpinRate;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        gameObject.transform.Rotate(0, 0, SpinRate, Space.Self);
    }
}
