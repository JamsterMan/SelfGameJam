﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FlashLight : MonoBehaviour
{
    public LayerMask playerLayer;
    private Vector3 lastMousePos;
    private float angle;

    private void Start()
    {
        lastMousePos = Vector3.zero;
    }

    void Update()
    {

        Vector3 mousePos = Input.mousePosition;
        if (mousePos != lastMousePos) {
            lastMousePos = mousePos;
            Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
            mousePos.x -= objectPos.x;
            mousePos.y -= objectPos.y;

            angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }

    }

    public float GetFlashLightAngle()
    {
        return angle;
    }

    //match x scale to the player
    public void FlipFlashLight()
    {
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
