using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXScript : MonoBehaviour
{

    public AudioSource Jump;
    public AudioSource Swap; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Swap.Play();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump.Play();
        }

    }
   
 }

