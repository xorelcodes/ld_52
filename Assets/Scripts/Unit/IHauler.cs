using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHauler 
{
    void DropOffResource(ResourceDropOff node);
    void SaveDropOffPoint(Collider2D dropOffPoint);
    void SavePickUpPoint(Collider2D pickUpPoint);
}
