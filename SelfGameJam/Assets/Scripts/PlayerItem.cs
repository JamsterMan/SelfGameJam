using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItem : MonoBehaviour
{
    private bool itemHeld;
    public Item[] item;

    // Start is called before the first frame update
    void Start()
    {
        itemHeld = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("PickUp") && !itemHeld) {
            Debug.Log("button pressed: item picked up");
        }else if(Input.GetButtonDown("PickUp") && itemHeld) {
            Debug.Log("button pressed: item dropped");
        }
    }
}
