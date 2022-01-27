using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabby : TwinCharacterController
{
    LayerMask grabMask;
    LayerMask dropMask;
    Vector3 searchdimensions = new Vector3(2, 5, 1);

    bool grabbed = false;
    IGrabbable grabbedTarget;
    
    // Start is called before the first frame update
    void Start()
    {
        init();
        grabMask = LayerMask.GetMask("Grabbable");
        dropMask = LayerMask.GetMask("Dropzone");
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();

        if (Input.GetKeyDown(KeyCode.E))
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
        Collider2D search = Physics2D.OverlapBox(transform.position, searchdimensions, 0, grabMask);
        //print("search");
        if (search != null)
        {
            //print(search.gameObject.name);
            grabbed = true;
            grabbedTarget = search.GetComponent<IGrabbable>();
            grabbedTarget.Grab(gameObject);

            //the object might already be in a drop zone, so we'll need to remove it if that's the case
            Collider2D dropSearch = Physics2D.OverlapBox(transform.position, searchdimensions, 0, dropMask);
            if (dropSearch != null)
            {
                DropZone zone = dropSearch.GetComponent<DropZone>();
                if (zone != null && !zone.CanPlaceBox() && zone.IsThisYourBox(grabbedTarget))
                {
                    zone.RemoveBox();
                }
            }
        }
    }

    void Drop()
    {
        //Search surroundings for dropzone
        Collider2D search = Physics2D.OverlapBox(transform.position, searchdimensions, 0, dropMask);
        //print("search");
        if (search != null)
        {
            grabbed = false;
            DropZone zone = search.GetComponent<DropZone>();
            if (zone != null && zone.CanPlaceBox())
            {
                grabbedTarget.Drop(zone.transform.position);
                zone.OnObjectPlaced(grabbedTarget);

                grabbedTarget = null;

                return;
            }
        }
        grabbed = false;

        grabbedTarget.Drop(transform.position + transform.forward * 1.1f + new Vector3(0,0.5f,0));
        grabbedTarget = null;
    }
}
