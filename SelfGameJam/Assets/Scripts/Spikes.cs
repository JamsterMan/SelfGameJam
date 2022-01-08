using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public PlayerController player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Spikes hit by: " + collision.name);
        player.PlayerDeath();
    }
}
