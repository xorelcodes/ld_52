using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    [SerializeField] private CameraFollow cameraFollow;
    
    private Vector3 cameraFollowPosition;
    private void Start(){

cameraFollow.Setup(() => cameraFollowPosition, () => 80f);

    }

    private void Update(){

float moveAmount = 20f;
        if(Input.GetKey(KeyCode.W)){
            cameraFollowPosition.y += moveAmount * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.S)){
            cameraFollowPosition.y -= moveAmount * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.D)){
            cameraFollowPosition.x += moveAmount * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.A)){
            cameraFollowPosition.x -= moveAmount * Time.deltaTime;
        }
    }

}
