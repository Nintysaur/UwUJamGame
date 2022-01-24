using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDropAction
{
    void OnActionCompleted();

    void OnActionReversed();
}
