using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public static float maxSpeed = 210000f;
    public static float minSpeed = 64074.6f;
    public static float speed;
    private Rigidbody rb;
    public static bool moving;
    private bool grounded;
    private float rollingSpeed;

    private Vector3 PastPos;

    public GameObject arrow;
    public GameObject powerBar;

    public static int score;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        arrowRotate();
        StopMoving();   
        Movement();
        if (rb.velocity.magnitude > 0.1)
        {
            moving = true;

        }
    }
    void Movement()
    {
        if (!moving)
        {
            powerBar.SetActive(true);
            arrow.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SavePos();
                rb.isKinematic = false;
                rb.AddForce(transform.forward * speed * Time.deltaTime);
                score++;
                powerBar.SetActive(false);
                arrow.SetActive(false);
                
            }
        }
    }
    void SavePos()
    {
        PastPos = transform.position;
    }
    void LoadPos()
    {
        rb.isKinematic = true;
        moving = false;
        transform.position = PastPos;
    }
    void StopMoving()
    {
        if (moving)
        {
            Rolling();
            powerBar.SetActive(false);
            arrow.SetActive(false);
            if (rb.velocity.magnitude < 0.1f && grounded == true)
            {
                powerBar.SetActive(true);
                arrow.SetActive(true);
                moving = false;
                rb.isKinematic = true;
                Debug.Log("Stopped");
            }
            else
            {
                rb.isKinematic = false;
                Debug.Log("Keep moving");
                
            }
        }
    }
    void arrowRotate()
    {
        Vector3 arrowPos = transform.position;
        arrowPos.y += 2;
        arrow.transform.position = arrowPos;

        arrow.transform.rotation = transform.rotation;
    }
    void Rolling()
    {
        rollingSpeed *= rb.velocity.magnitude;
        transform.Rotate(rollingSpeed, 0, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Water")
        {
            LoadPos();
        }
        if(collision.gameObject.tag == "floor")
        {
            grounded = true;
        }

    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "floor")
        {
            grounded = false;
        }
    }


}
