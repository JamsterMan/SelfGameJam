using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FlashLight : MonoBehaviour
{
    public int layerLightable = 10;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.layer == layerLightable) {
            Debug.Log("object entered: " + collision.name);
            //collision.gameObject.GetComponent<TilemapRenderer>().SetActive(true);

            collision.gameObject.GetComponent<TilemapRenderer>().enabled = true;
            collision.gameObject.GetComponent<CompositeCollider2D>().isTrigger = false;
            Debug.Log(collision.bounds.center);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == layerLightable) {
            Debug.Log("object exit: " + collision.name);
            //collision.gameObject.SetActive(false);
            collision.gameObject.GetComponent<TilemapRenderer>().enabled = false;
            collision.gameObject.GetComponent<CompositeCollider2D>().isTrigger = true;
        }
    }
}
