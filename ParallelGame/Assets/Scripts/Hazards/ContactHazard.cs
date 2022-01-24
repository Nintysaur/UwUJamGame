using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactHazard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        TwinCharacterController twin = collision.gameObject.GetComponent<TwinCharacterController>();
        if (twin == null)
        {
            return;
        }

        //Contact Hazard effect
        twin.HazardContact();
    }

    private void OnCollisionEnter(Collision collision)
    {
        TwinCharacterController twin = collision.gameObject.GetComponent<TwinCharacterController>();
        if (twin == null)
        {
            return;
        }

        //Contact Hazard effect
        twin.HazardContact();
    }
}
