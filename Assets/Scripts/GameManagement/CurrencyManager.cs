using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager Instance;

    /**
    Calling these would be CurrencyManager.Instance.PollenCount  and CurrencyManager.Instance.PartsCount
    Setting these would be CurrencyManager.Instance.PollenCount = 5 or CurrencyManager.Instance.PollenCount += 5
    */
    
    public int PollenCount = 0;
    public int PartsCount = 0;
    
     void Awake(){
        if(Instance != null){
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
     }
}
