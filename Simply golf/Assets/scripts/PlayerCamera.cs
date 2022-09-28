using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform player;
    

    [Header("cameraRotation")]
    public float sensetivity;
    private Vector2 turn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Position();
        Rotation();
    }
    void Position()
    {
        transform.position = player.position;

    }
    void Rotation()
    {
        player.localRotation = transform.rotation;
        if(Input.GetMouseButton(1))
        {
            turn.x += Input.GetAxis("Mouse X") * sensetivity;
            turn.y += Input.GetAxis("Mouse Y") * sensetivity;
            transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);

        }

    }
}
