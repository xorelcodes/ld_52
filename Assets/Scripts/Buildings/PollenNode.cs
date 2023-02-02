using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollenNode : MonoBehaviour
{
    public float TimeToGather = 0;
    float CurrentGatheringTime;

    private Collider mColider;

    private int heldPollen = 5000;

    // Start is called before the first frame update
    void Start()
    {
        CurrentGatheringTime = TimeToGather;
        mColider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Vector3 ObjectCenter()
    {
        return mColider.bounds.center;
    }

    public int PickUpPollen()
    {
        heldPollen -= 1;
        Debug.Log("Pollen received, node has " + heldPollen + " left");
        return 1;
    }
  
}
