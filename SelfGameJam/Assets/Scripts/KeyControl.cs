﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyControl : MonoBehaviour
{
    public PlayerController player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.PickUpKey(this);
        gameObject.SetActive(false);
    }

    public void SetKeyVisable()
    {
        gameObject.SetActive(true);
    }
}
