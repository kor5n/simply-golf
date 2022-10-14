using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPivot : MonoBehaviour
{
    public Transform player;

    [Header("aboutCamera")]
    public Transform rCamera;// real camera
    public float zoomSpeed;
    public float sensetivity;
    private Vector2 turn;
    void Update()
    {
        Position();
        Rotation();
        ZoomCam();
    }
    void Position()
    {
        transform.position = player.position;// camera pivot has the same position as the player
    }
    void Rotation()
    {
        if (!Player.moving)
        {
            player.localRotation = transform.rotation;// you controll the golf balls rotation
            if (Input.GetMouseButton(1))// right click
            {
                turn.x += Input.GetAxis("Mouse X") * sensetivity;
                turn.y += Input.GetAxis("Mouse Y") * sensetivity;
                transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);

            }
        }
    }
    void ZoomCam()
    {
        if(!Player.moving)
        {
            
            if(Input.GetAxis("Mouse ScrollWheel") > 0)// scrolling up
            {
                rCamera.position = Vector3.MoveTowards(rCamera.position, player.position, zoomSpeed);
            }
            else if(Input.GetAxis("Mouse ScrollWheel") < 0)// scrolling down
            {
                rCamera.position -= transform.forward * zoomSpeed;
            }
        }
    }
}
