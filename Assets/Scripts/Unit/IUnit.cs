using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnit
{
    void MoveUnit(Vector3 destination);
    void StopMovement();
    void SelectUnit();
    void ClearSelection();
    void OnMouseDown();
    IEnumerator MoveCommand(Vector3 start, Vector3 end);
}
