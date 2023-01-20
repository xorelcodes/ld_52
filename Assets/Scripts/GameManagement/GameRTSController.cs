using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRTSController : MonoBehaviour
{

[SerializeField] private Transform selectionAreaTransform;


List<BeeUnit> selectedBeeUnits;
Vector3 worldPosition;
Vector3 startPosition;
Vector3 endPosition;

void Awake(){
    selectedBeeUnits = new List<BeeUnit>();
    selectionAreaTransform.gameObject.SetActive(false);
}

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
                 
        startPosition = GetMousePosition();
    selectionAreaTransform.gameObject.SetActive(true);

        }
        if(Input.GetMouseButton(0)){
            Vector3 currentMousePosition = GetMousePosition();
            Vector3 lowerLeft = new Vector3(
                Mathf.Min(startPosition.x, currentMousePosition.x),
                Mathf.Min(startPosition.y, currentMousePosition.y)
            );
            Vector3 upperRight = new Vector3(
                
                Mathf.Max(startPosition.x, currentMousePosition.x),
                Mathf.Max(startPosition.y, currentMousePosition.y)
            );
            selectionAreaTransform.position = lowerLeft;
            selectionAreaTransform.localScale = upperRight - lowerLeft;
        }
        if(Input.GetMouseButtonUp(0)){

            Collider2D[] collider2DArray = Physics2D.OverlapAreaAll(startPosition, GetMousePosition());
            
    selectionAreaTransform.gameObject.SetActive(false);
             foreach(BeeUnit beeUnit in selectedBeeUnits){
               beeUnit.ClearSelection();
            }
            selectedBeeUnits.Clear();

            foreach(Collider2D collider2D in collider2DArray){
                BeeUnit beeUnit = collider2D.GetComponent<BeeUnit>();
                if(beeUnit!= null){
                    selectedBeeUnits.Add(beeUnit);
                    beeUnit.SelectUnit();
                }
            }

            Debug.Log(selectedBeeUnits.Count);
        }

        if(Input.GetMouseButtonDown(1)){
            Vector3 destination = GetMousePosition();

            List<Vector3>targetPositionList = GetPositionListAround(destination, 1f, 5);

            int targetPositionListIndex = 0;
            foreach(BeeUnit beeUnit in selectedBeeUnits){
                beeUnit.StopAllCoroutines();
                beeUnit.MoveUnit(targetPositionList[targetPositionListIndex]);
                targetPositionListIndex = (targetPositionListIndex + 1) % targetPositionList.Count;
            }
        }
       
    }

private List<Vector3> GetPositionListAround(Vector3 startPosition, float distance, int positionCount){
    List<Vector3> positionList = new List<Vector3>();
    for(int i = 0; i < positionCount; i++){
        float angle = i * (360f / positionCount);
        Vector3 dir = ApplyRotationToVector(new Vector3(1, 0), angle);
        Vector3 position = startPosition + dir * distance;
        positionList.Add(position);
    }
    return positionList;
}

private Vector3 ApplyRotationToVector(Vector3 vec, float angle){
    return Quaternion.Euler(0, 0, angle) * vec;
}
    private Vector3 GetMousePosition(){
     
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }



}
