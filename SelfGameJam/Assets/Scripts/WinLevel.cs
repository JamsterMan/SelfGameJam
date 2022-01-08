using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Level Complete");
        //go to next scene
    }
}
