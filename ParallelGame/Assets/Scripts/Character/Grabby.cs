using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabby : TwinCharacterController
{
    LayerMask grabMask;

    bool grabbed = false;
    IGrabbable grabbedTarget;
    
    // Start is called before the first frame update
    void Start()
    {
        init();
        grabMask = LayerMask.GetMask("Grabbable");
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();

        if (Input.GetButtonDown("Jump"))
        {
            if (grabbed)
            {
                Drop();
            }
            else
            {
                Grab();
            }            
        }
    }

    void Grab()
    {
        //Search surroundings for grabbable objects
        Vector3 searchdimensions = new Vector3(2, 5, 1);
        Collider2D search = Physics2D.OverlapBox(transform.position, searchdimensions, 0, grabMask);
        //print("search");
        if (search != null)
        {
            //print(search.gameObject.name);
            grabbed = true;
            grabbedTarget = search.GetComponent<IGrabbable>();
            grabbedTarget.Grab(gameObject);
        }
    }

    void Drop()
    {
        grabbed = false;
        
        grabbedTarget.Drop();
        grabbedTarget = null;

    }
}
