using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGrabbable
{
    Compatability GetCompatability();
    
    void Grab(GameObject grabber );

    void Drop(Vector3 dropAt);
}

public enum Compatability
{
    Red,
    Blue,
    Yellow,
    Green
}
