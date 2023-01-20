using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    public GameObject selectSprite;
 
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown() {
        selectSprite.SetActive(true);
    }
}
