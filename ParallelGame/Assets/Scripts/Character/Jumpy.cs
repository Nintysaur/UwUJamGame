using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpy : TwinCharacterController
{
    // Start is called before the first frame update
    void Start()
    {
        init();
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();

        if (Input.GetButtonDown("Jump") && onFloor())
        {
            //rb.AddForce(transform.up * 800f);
        }

        if (Input.GetKeyDown(KeyCode.Q)) //Swap
        {
            //Get both current positions
            Vector3 myPosition = transform.position;
            Vector3 twinPosition = twin.transform.position;

            //Switch positions
            transform.position = twinPosition;
            twin.transform.position = myPosition;
        }
    }    
}
