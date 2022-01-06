using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItem : MonoBehaviour
{
    private bool itemHeld;

    // Start is called before the first frame update
    void Start()
    {
        itemHeld = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("PickUp") && !itemHeld) {
            Debug.Log("button pressed: item picked up");
            itemHeld = true;
        }else if(Input.GetButtonDown("PickUp") && itemHeld) {
            Debug.Log("button pressed: item dropped");
            itemHeld = false;
        }
    }
}
