using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FlashLight : MonoBehaviour
{
    public LayerMask playerLayer;
    private Vector3 lastMousePos;
    private float angle;
    private float flipAngle;//too keep flash light working when player turns

    private void Start()
    {
        lastMousePos = Vector3.zero;
        flipAngle = 1;
    }

    void Update()
    {
        //lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        Vector3 mousePos = Input.mousePosition;
        if (mousePos != lastMousePos) {
            Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
            mousePos.x -= objectPos.x;
            mousePos.y -= objectPos.y;

            angle = Mathf.Atan2(mousePos.y * flipAngle, mousePos.x * flipAngle) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            lastMousePos = mousePos;
        }

        if (Input.GetMouseButtonDown(0)) {
            //FireOrb();
        }
        /*if (Input.GetButtonDown("PickUp")) {
            Debug.Log("button pressed");
        }*/
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(collision.name + " : " + collision.IsTouchingLayers(playerLayer));
        if (collision.IsTouchingLayers(playerLayer)) {
            if (Input.GetButtonDown("PickUp")) {
                Debug.Log("button pressed: " + collision.name);
            }
        }
    }

    public float GetFlashLightAngle()
    {
        return angle;
    }

    public void FlipFlashLight()
    {
        flipAngle *= -1;
    }
}
