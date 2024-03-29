﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotate : MonoBehaviour
{
    // Start is called before the first frame update

    public float SpinRate;
    public float OrbitalPeriod;
    public float AngleDegs;
    public float OrbitRadius;
    private float _angleRads;

    void Start()
    {
        _angleRads = 0.0f + Mathf.PI * AngleDegs / 180.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //Do orbital motion
        AngleDegs = 180.0f * _angleRads / Mathf.PI;
        var deltaAngleRads = 2.0f * Mathf.PI * Time.deltaTime / OrbitalPeriod;
        _angleRads += deltaAngleRads;
        if(_angleRads > 2.0f * Mathf.PI)
        {
            _angleRads = 0.0f;
        }
        var newX = OrbitRadius * Mathf.Cos(_angleRads);
        var newY = OrbitRadius * Mathf.Sin(_angleRads);
        var z = GameController.Control.PlanetZ;
        gameObject.transform.position = new Vector3(newX, newY, z);

        //Spin on axis
        gameObject.transform.Rotate(0, 0, SpinRate, Space.Self);
    }
}
