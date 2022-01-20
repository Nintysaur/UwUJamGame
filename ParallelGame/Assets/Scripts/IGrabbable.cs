using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGrabbable
{
    void Grab(GameObject grabber );

    void Drop();
}
