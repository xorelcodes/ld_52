using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceDropOff : MonoBehaviour
{

    public void DepositResources(int resource)
    {
        CurrencyManager.Instance.PollenCount += resource;
    }
}
