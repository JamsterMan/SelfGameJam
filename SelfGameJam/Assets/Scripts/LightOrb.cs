using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LightOrb : MonoBehaviour
{
    public Vector3 orbIdlePosition;
    public Transform player;

    public int layerLightable = 10;
    public int layerGround = 9;
    private Vector2 lookDirection;
    private bool orbUsed = false;

    //private Light orbLight;
    public GameObject orbSprite;

    private void Start()
    {
        //orbLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        if (Input.GetMouseButtonDown(0) && !orbUsed) {
            FireOrb();
        }
        if (Input.GetMouseButtonDown(1)) {
            UnuseOrb();
            ReturnToStartPos();
        }
    }

    private void FireOrb()
    {
        //Debug.Log(lookDirection + " : " + Camera.main.ScreenToWorldPoint(Input.mousePosition) + " : " + transform.position);
        
        GetComponent<Rigidbody2D>().velocity = lookDirection;
    }

    //return to moving with the player
    private void ReturnToStartPos()
    {
        StopOrb();
        if (player.localScale.x > 0) {//returns to in front of the player if they face left or right
            transform.position = orbIdlePosition + player.position;
        } else {
            transform.position = -orbIdlePosition + player.position;
        }
    }

    //stop the velocity of the orb
    private void StopOrb()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    private void UseOrb()
    {
        orbUsed = true;
        //orbLight.enabled = false;
        orbSprite.GetComponent<SpriteRenderer>().enabled = false;
    }

    private void UnuseOrb()
    {
        orbUsed = false;
        //orbLight.enabled = true;
        orbSprite.GetComponent<SpriteRenderer>().enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.layer == layerLightable) {
            Debug.Log("hit Lightable object: " + collision.name);

            UseOrb();
            orbSprite.GetComponent<SpriteRenderer>().enabled = false;
            orbUsed = true;
            StopOrb();
        }
        if (collision.gameObject.layer == layerGround) {
            Debug.Log("hit Ground object: " + collision.name);
            ReturnToStartPos();
        }
    }
}
