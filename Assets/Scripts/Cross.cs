using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cross : MonoBehaviour
{
    [SerializeField] private float angleRotation = 20.0f;
    
    [SerializeField] private float upFactor = 20f;
    [SerializeField] private float minVal = 0.8f;
    [SerializeField] private float sinEffect = 0.8f;

    private float upValue = 0.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, Time.deltaTime * angleRotation);
        
        //upValue += upFactor * Time.deltaTime;
        //var position = transform.position;
        //position.y = minVal + sinEffect * Math.Abs(Mathf.Sin(upFactor * Mathf.Deg2Rad));
        //transform.position = position;
    }
}
