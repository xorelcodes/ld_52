using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCameraMovement : MonoBehaviour
{
    public float scrollSpeed = .003f;
    public GameObject sidebar;

    void Start(){
        
    }
void Update()
{

//int scrollDistance = 15;

// if (mousePosX < scrollDistance)
// {
// transform.Translate(Vector3.right * -scrollSpeed * Time.deltaTime);
// }

// if (mousePosX >= Screen.width - 450 - scrollDistance)
// {
// transform.Translate(Vector3.right * scrollSpeed * Time.deltaTime);
// }

// if (mousePosY < scrollDistance)
// {
// transform.Translate(Vector3.down * scrollSpeed * Time.deltaTime);
// }

// if (mousePosY >= Screen.height - scrollDistance)
// {
// transform.Translate(Vector3.up * scrollSpeed * Time.deltaTime);
// }
if (Input.GetKey(KeyCode.A))
{
transform.Translate(Vector3.right * -scrollSpeed * Time.deltaTime);
}

if (Input.GetKey(KeyCode.D))
{
transform.Translate(Vector3.right * scrollSpeed * Time.deltaTime);
}

if (Input.GetKey(KeyCode.S))
{
transform.Translate(Vector3.down * scrollSpeed * Time.deltaTime);
}

if (Input.GetKey(KeyCode.W))
{
transform.Translate(Vector3.up * scrollSpeed * Time.deltaTime);
}



}
}
