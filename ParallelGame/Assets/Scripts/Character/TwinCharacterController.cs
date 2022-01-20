using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TwinCharacterController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] protected GameObject twin;

    protected Rigidbody2D rb;

    protected void init()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected void HandleInput()
    {
        //we'll just use the old input system
        //Horizontal Movement
        float move = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        //print(move);
        if (onFloor())
        {
            rb.AddForce(new Vector2(move, 0), ForceMode2D.Force);
        }        
    }

    protected bool onFloor()
    {
        LayerMask mask = LayerMask.GetMask("Terrain");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 0.15f, mask);

        if (hit.collider == null)
        {
            return false;
        }

        return true;
    }
}
