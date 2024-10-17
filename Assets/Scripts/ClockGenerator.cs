using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockGenerator : MonoBehaviour
{
    /*
     * I don't know why I am doing this lol.
     * 
     */


    

    const int hourCount = 14;

    const float minuteHandScaleX = 0.5f;
    const float minuteHandScaleY = 0.5f;
    const float minuteHandScaleZ = 9.5f;

    const float hourHandScaleX = 0.7f;
    const float hourHandScaleY = 0.5f;
    const float hourHandScaleZ = 7.5f;
    
    const float faceScaleX = 1.0f;
    const float faceScaleY = 0.05f;
    const float faceScaleZ = 1.0f;

    const float markerScaleX = 1.0f;
    const float markerScaleY = 1.5f;
    const float markerScaleZ = 1.0f;
    [HideInInspector]
    public Transform hourHand;
    [HideInInspector]
    public Transform minuteHAnd;
    //Generate the clock face
    //WTH lol
    private Transform GenerateClockPart(Color partColor,float scaleMultiplier,float scaleX,float scaleY,float scaleZ,Vector3 rotationAngles,Vector3 offset,PrimitiveType primitive)
    {
        GameObject clockPart = GameObject.CreatePrimitive(primitive);
        clockPart.transform.position = -offset;
        clockPart.transform.rotation = Quaternion.Euler(rotationAngles);
        clockPart.GetComponent<Renderer>().material.color = partColor;
        clockPart.transform.localScale = new Vector3(scaleX, scaleY, scaleZ) * scaleMultiplier;
        return clockPart.transform;
    }


    
    //Place the markers

    //Scale and place the hands

    private void GenerateClockMarkers()
    {
        for(int i = 0; i < hourCount; i++)
        {
            float angle = i * 2 * Mathf.PI / hourCount;
            GenerateClockPart(Color.black, 1, markerScaleX, markerScaleY, markerScaleZ, new Vector3(0,180 , angle * Mathf.Rad2Deg), new Vector3(Mathf.Sin(angle) * 10, Mathf.Cos(angle) * 10, 2.5f) , PrimitiveType.Cube);
        }
    }

    private void Start()
    {
        GenerateClockPart(Color.white,25,faceScaleX,faceScaleY,faceScaleZ,new Vector3(90,0,0),Vector3.zero,PrimitiveType.Cylinder);
        hourHand = GenerateClockPart(Color.black,1,hourHandScaleX, hourHandScaleY, hourHandScaleZ, new Vector3(90, 0, 0),new Vector3(1,  -2, 2.5f), PrimitiveType.Cube);
        minuteHAnd = GenerateClockPart(Color.red,1, minuteHandScaleX, minuteHandScaleY, minuteHandScaleZ, new Vector3(90, 2.5f, 2.5f), new Vector3(0, -3, 2.5f), PrimitiveType.Cube);
        GenerateClockMarkers();
    }
}
