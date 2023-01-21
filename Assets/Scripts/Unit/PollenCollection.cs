using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollenCollection : MonoBehaviour
{
    public float TimeToGather=0;
    float CurrentGatheringTime;
    
    // Start is called before the first frame update
    void Start()
    {
        CurrentGatheringTime = TimeToGather;    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionStay2D(Collision2D other) 
    {
        
        if(other.gameObject.CompareTag("Worker"))
        {
            if(CurrentGatheringTime>0)
            {
                CurrentGatheringTime-=Time.fixedDeltaTime;
            }
            else if(CurrentGatheringTime<=0)
            {
                CurrencyManager.Instance.PollenCount+=1;
                CurrentGatheringTime=TimeToGather;
            }
        } 
    }
}
