using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    private PlayerController player;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger Entered by: " + collision.name);
        if(player.UsePlayerKey())
            transform.parent.gameObject.SetActive(false);//removes door
    }
}
