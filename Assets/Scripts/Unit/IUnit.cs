using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnit
{
    
    bool isIdle();
    void MoveTo(Vector3 position, float stopdistance, AccelerationEvent onArrivedAtPosition);
    void PlayAnimationGather(Vector3 lookAtPosition, AccelerationEvent onAnimationCompleted);
}
