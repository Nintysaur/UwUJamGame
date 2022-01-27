using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropZone : MonoBehaviour
{
    public Compatability compatability;

    private IGrabbable storedBox;

    [SerializeField] private GameObject linkedGameObject;
    private IDropAction linkedObject;
    
    // Start is called before the first frame update
    void Start()
    {
        storedBox = null;
        linkedObject = linkedGameObject.GetComponent<IDropAction>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CanPlaceBox()
    {
        if (storedBox == null)
        {
            return true;
        }

        return false;
    }

    public bool IsThisYourBox(IGrabbable box)
    {
        if (box == storedBox)
        {
            return true;
        }
        return false;
    }

    public void OnObjectPlaced(IGrabbable box)
    {
        //store the box
        storedBox = box;
        
        //If the object aren't compatible, this is as far as we go.
        if (box.GetCompatability() != compatability)
        {
            return;
        }

        //Do the compat thing
        print("Compatible");

        if (linkedObject != null)
        {
            linkedObject.OnActionCompleted();
        }        
    }

    public void RemoveBox()
    {
        storedBox = null;

        if (linkedObject != null)
        {
            linkedObject.OnActionReversed();
        }

        //print("RemoveBox");
    }
}
