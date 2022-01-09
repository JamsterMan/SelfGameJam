using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private PlayerController player;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Spikes hit by: " + collision.name);
        player.PlayerDeath();
    }
}
