using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabBox : MonoBehaviour, IGrabbable
{
    bool follow = false;
    Transform followTarget = null;

    Collider2D myCollider;

    Vector3 followOffset = new Vector3(0,2.5f,0);
    
    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (follow && followTarget != null)
        {
            transform.position = followTarget.position + followOffset;
        }
    }
    public Compatability GetCompatability()
    {
        return Compatability.Red;
    }

    public void Grab( GameObject grabber)
    {
        follow = true;
        followTarget = grabber.transform;

        myCollider.enabled = false;
    }

    public void Drop( Vector3 dropAt )
    {
        transform.position = dropAt;

        follow = false;
        followTarget = null;

        myCollider.enabled = true;
    }    
}
