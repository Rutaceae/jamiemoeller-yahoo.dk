﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HBridgePin : ArduinoObject
{
    public enum PinType
    {
        DriveForward, DriveBackward
    };

    [SerializeField]
    private PinType pinType;

    [SerializeField]
    private HBridge hBridge; //assign in inspector - otherwise it finds it through its parent.

    void Start()
    {
        if (hBridge == null)
        {
            hBridge = transform.GetComponentInParent<HBridge>();
        }
    }

    override public int analogRead()
    {
        //Not sure what reading on a H-bridge would return. Could debug a warning.
        throw new NotImplementedException();
    }
    override public void analogWrite(int value)
    {
        if (value < 0 || value > 255)
        {
            Debug.LogWarning("analogWrite used with values outside range of [0;255], value was clamped within this range.");
        }
        int val = Mathf.Clamp(value, 0, 255);
        hBridge.SetMotorSpeedAndDirection(pinType, val);
    } 
    override public bool digitalRead()
    {
        //Not sure what reading on a H-bridge would return. Could debug a warning.
        throw new NotImplementedException();
    }
    override public void digitalWrite(bool isHigh)
    {
        //Could have this analogWrite with max or minimum values 255 and 0 respectively. For now it's not implemented.
        throw new NotImplementedException();
    }


}