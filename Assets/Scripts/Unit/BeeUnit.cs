using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BeeUnit : MonoBehaviour
{

Vector3 worldPosition;
    private bool isSelected = false;
    public GameObject selectSprite;
       private Vector3 currentPos;
    private Vector3 goToPosition;
    SpriteRenderer spriteRenderer;
    bool isMoving = false;

    private IEnumerator movementCoroutine;

    public float MovementSpeed = 3f;
 
void Start(){
    spriteRenderer = GetComponent<SpriteRenderer>();
}

    // Update is called once per frame
    void Update()
    {
         if(Input.GetMouseButtonDown(1) && !isMoving){
            
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        Debug.Log("Mouse Position|   X: " + worldPosition.x + " Y: " + worldPosition.y);

        if(isSelected){

         //   transform.position = worldPosition;

          //  currentPos = transform.position;

           // StartCoroutine(MoveCommand(currentPos, worldPosition));

            
        }
        }
    }

public void MoveUnit(Vector3 destination){
    currentPos = transform.position;
    movementCoroutine = MoveCommand(currentPos, destination);
            StartCoroutine(movementCoroutine);
}

public void StopMovement(){
    StopCoroutine(movementCoroutine);
}
public void SelectUnit(){
    isSelected = true;
        selectSprite.SetActive(true);

}

public void ClearSelection(){
    isSelected = false;
    selectSprite.SetActive(false);
}
    private void OnMouseDown() {
        Debug.Log("Bee Clicked");
        selectSprite.SetActive(true);
        isSelected = true;
    }

   IEnumerator MoveCommand(Vector3 start, Vector3 end)
    {
            float elapsedTime = 0;

            if(start.x < end.x){
                spriteRenderer.flipX = true;
            }else{
                spriteRenderer.flipX = false;
            }

                    isMoving = true;
             while (elapsedTime < MovementSpeed)
                {
                    elapsedTime += Time.deltaTime;
                    if (elapsedTime > MovementSpeed) elapsedTime = MovementSpeed;
                    float newTime = elapsedTime / MovementSpeed;
                    newTime = newTime * newTime * (3f - 2f * newTime);

                    transform.position = Vector3.Lerp(start, end, newTime);

                    yield return null;
                }
                isMoving = false;
            
                    yield return null;
    }
}
