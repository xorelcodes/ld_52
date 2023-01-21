using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ResourceUpdater : MonoBehaviour
{
    public TMP_Text PollenCountText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PollenCountText.SetText((CurrencyManager.Instance.PollenCount).ToString());
    }
}
