using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyControl : MonoBehaviour
{
    private PlayerController player;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

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
