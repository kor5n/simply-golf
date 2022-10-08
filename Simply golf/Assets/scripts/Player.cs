using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public static float maxSpeed = 200000f;
    public static float minSpeed = 24074.6f;
    public static float speed;
    private Rigidbody rb;
    private bool moving;
    private bool grounded;

    private Vector3 PastPos;
    
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
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SavePos();
                rb.isKinematic = false;
                rb.AddForce(transform.forward * speed * Time.deltaTime);
                score++;
                powerBar.SetActive(false);
                
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
            powerBar.SetActive(false);
            if (rb.velocity.magnitude < 0.1f && grounded == true)
            {
                powerBar.SetActive(true);
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
