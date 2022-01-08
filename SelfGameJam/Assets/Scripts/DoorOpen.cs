using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public PlayerController player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger Entered by: " + collision.name);
        if(player.UsePlayerKey())
            transform.parent.gameObject.SetActive(false);//removes door
    }
}
