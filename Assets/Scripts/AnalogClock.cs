using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(ClockGenerator))]
public class AnalogClock : MonoBehaviour
{
 
    private ClockGenerator _clockGenerator;

    private void Start()
    {
        _clockGenerator = GetComponent<ClockGenerator>();
    }

    private void Update()
    {
        _clockGenerator.hourHand.transform.rotation = Quaternion.Euler((float)(-30 * DateTime.Now.TimeOfDay.TotalHours), 90, 0);
        _clockGenerator.minuteHAnd.transform.rotation = Quaternion.Euler((float)(-6 * DateTime.Now.TimeOfDay.TotalMinutes), 90, 0);
    }
}
