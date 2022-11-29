using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public static float minSpeed = 200f;
    public static float maxSpeed = 2800f;
    public static float speed;
    private Rigidbody rb;
    
    private float rollingSpeed;

    [Header("Conditions")]
    public static bool moving;
    private bool grounded;
    public static bool isDead;
    public static int BoostType;

    [Header("Extra Components")]
    public GameObject arrow;
    public GameObject powerBar;

    private Vector3 PastPos;
    public static int score;
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        arrowRotate();

        StopMoving();

        Movement();

        Rolling();

        Boost();
        if (rb.velocity.magnitude > 0.1f)
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
                rb.AddForce(transform.forward * speed * Time.deltaTime, ForceMode.Impulse);
                score++;
                powerBar.SetActive(false);
                arrow.SetActive(false);
                
            }
        }
    }
    void SavePos()
    {
        PastPos = transform.position;// saving your position
    }
    void LoadPos()
    {
        isDead = true;

        rb.isKinematic = true;
        moving = false;
        transform.position = PastPos;
    }
    void StopMoving()
    {
        if (moving)
        {
            
            powerBar.SetActive(false);
            arrow.SetActive(false);
            if (rb.velocity.magnitude < 0.1f && grounded == true)
            {
                powerBar.SetActive(true);
                arrow.SetActive(true);
                moving = false;// you are not moving(mentaly)
                rb.isKinematic = true;// you are not moving(physicaly)
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
        if (moving)
        {
            rollingSpeed *= rb.velocity.magnitude;
            transform.Rotate(rollingSpeed, 0, 0);
        }
        
    }
    void Boost()
    {
        if (BoostType == 1)//isZ
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z + 0.5f);
        }
        else if (BoostType == 2)//isMinusZ
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z - 0.5f);
        }
        else if (BoostType == 3)//isX
        {
            rb.velocity = new Vector3(rb.velocity.x + 0.5f, rb.velocity.y, rb.velocity.z);
        }
        else if (BoostType == 4)//isMinusX
        {
            rb.velocity = new Vector3(rb.velocity.x - 0.5f, rb.velocity.y, rb.velocity.z);
        }
        else
        {
            Debug.Log("NO BOOST!");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Water")
        {
            LoadPos();// load the position you have shooten from
        }
        if(collision.gameObject.tag == "floor")
        {
            grounded = true;
        }

    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            LoadPos();// load the position you have shooten from
        }
        if (collision.gameObject.tag == "floor")
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
