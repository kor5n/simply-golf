using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPivot : MonoBehaviour
{
    public Transform playerTransf;

    [Header("aboutCamera")]
    public Transform rCamera;// real camera
    public float zoomSpeed;
    public float sensetivity;
    private Vector2 turn;
    public float cameraSpeed = 0;
    void Update()
    {
        Position();
        Rotation();
        ZoomCam();
    }
    void Position()
    {
        
        if (!Player.isDead)
        {
            cameraSpeed = 20f;  
        }
        else if (Player.isDead)
        {
            cameraSpeed = 60f;
            transform.LookAt(playerTransf);
        }
        if(transform.position == playerTransf.position)
        {
            Player.isDead = false;
        }
        
        transform.position = Vector3.MoveTowards(transform.position, playerTransf.position, cameraSpeed * Time.deltaTime);


    }
    void Rotation()
    {
        if (Input.GetMouseButton(1))// right click
        {
            turn.x += Input.GetAxis("Mouse X") * sensetivity;
            turn.y += Input.GetAxis("Mouse Y") * sensetivity;
            transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
        }
        if (!Player.moving)
        {
            playerTransf.localRotation = Quaternion.Euler(0, turn.x, 0);
        }
    }
    void ZoomCam()
    {
        if(Input.GetAxis("Mouse ScrollWheel") > 0)// scrolling up
        {
            rCamera.position = Vector3.MoveTowards(rCamera.position, transform.position, zoomSpeed);
        }
        else if(Input.GetAxis("Mouse ScrollWheel") < 0)// scrolling down
        {
            rCamera.position -= transform.forward * zoomSpeed;
        }
        
    }
    
}
