using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee_Worker : MonoBehaviour, IUnit, IHauler
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

    private int heldPollen = 0;
    private int maxPollen = 5;
    private int dropOffRate = 1;
    public Collider2D savedResourceDropOff;
    public Collider2D savedResourcePickup;

    public float TimeToGather = 1;
    public float TimeToDropOff = .5f;
    float CurrentGatheringTime;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && !isMoving)
        {

            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.nearClipPlane;
            worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
            Debug.Log("Mouse Position|   X: " + worldPosition.x + " Y: " + worldPosition.y);

        }
    }
    public void ClearSelection()
    {
        isSelected = false;
        selectSprite.SetActive(false);
    }


    public void MoveUnit(Vector3 destination)
    {
        currentPos = transform.position;
        movementCoroutine = MoveCommand(currentPos, destination);
        StartCoroutine(movementCoroutine);
    }

    public void OnMouseDown()
    {
        Debug.Log("Bee Clicked");
        selectSprite.SetActive(true);
        isSelected = true;
    }

    public void SelectUnit()
    {
        isSelected = true;
        selectSprite.SetActive(true);
    }

    public void StopMovement()
    {
        StopCoroutine(movementCoroutine);
    }


   
    public void DropOffResource(ResourceDropOff node)
    {

 if (CurrentGatheringTime > 0)
        {
            CurrentGatheringTime -= Time.fixedDeltaTime;
        }
        else if (CurrentGatheringTime <= 0 && heldPollen > 0)
        {

            node.DepositResources(dropOffRate);
            heldPollen -= dropOffRate;

            CurrentGatheringTime = dropOffRate;
        }
    }

    public void SaveDropOffPoint(Collider2D dropOffPoint)
    {
        savedResourceDropOff = dropOffPoint;
    }

    public void SavePickUpPoint(Collider2D pickUpPoint)
    {
        savedResourcePickup = pickUpPoint;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (isMoving == false)
        {

            switch (other.gameObject.tag)
            {
                case "GatherNode":
                    if (heldPollen == maxPollen)
                    {

                        MoveUnit(savedResourceDropOff.bounds.center);
                        return;
                    }

                    PollenNode node = other.GetComponent<PollenNode>();
                    CollectPollen(node);


                    break;

                case "DropOffNode":
                    if (heldPollen == 0)
                    {
                        MoveUnit(savedResourcePickup.bounds.center);
                        return;
                    }

                    ResourceDropOff dropOff = other.GetComponent<ResourceDropOff>();
                    DropOffResource(dropOff);


                    break;

                default:

                    break;

            }

        }

    }

    private void CollectPollen(PollenNode node)
    {

        if (CurrentGatheringTime > 0)
        {
            CurrentGatheringTime -= Time.fixedDeltaTime;
        }
        else if (CurrentGatheringTime <= 0 && heldPollen < maxPollen)
        {

            heldPollen += node.PickUpPollen();

            CurrentGatheringTime = TimeToGather;
        }
    }
    public IEnumerator MoveCommand(Vector3 start, Vector3 end)
    {
        float elapsedTime = 0;

        if (start.x < end.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
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
