using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class TwinCharacterController : MonoBehaviour
{
    [SerializeField] protected GameObject twin;

    protected Rigidbody rb;

    protected void init()
    {
        rb = GetComponent<Rigidbody>();
    }

    protected void HandleInput()
    {
        //we'll just use the old input system
        //Horizontal Movement
        //float move = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        //print(move);
        //if (onFloor())
        //{
        //    rb.AddForce(new Vector2(move, 0), ForceMode2D.Force);
        //}        
    }

    protected bool onFloor()
    {
        LayerMask mask = LayerMask.GetMask("Terrain");
        //RaycastHit hit = Physics.Raycast(transform.position, -Vector2.up, 0.15f, mask);

        //if (hit.collider == null)
        //{
        //    return false;
        //}

        return true;
    }

    public void HazardContact()
    {
        //For now just reset the scene
        Scene c_scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(c_scene.name);
    }
}
