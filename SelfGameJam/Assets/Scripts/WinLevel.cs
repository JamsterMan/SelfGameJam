using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLevel : MonoBehaviour
{
    private PlayerController player;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Level Complete");
        player.ResetPlayerPosition();
        //go to next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
