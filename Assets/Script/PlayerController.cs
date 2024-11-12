using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroll : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    public Camera cam;

    private Vector2 movement;
    private Vector2 mousePos;
   

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed *Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    
}
