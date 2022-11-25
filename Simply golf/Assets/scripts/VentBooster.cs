using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentBooster : MonoBehaviour
{
    [Header("Type of fan")]
    public bool isX;
    public bool isMinusX;
    public bool isZ;
    public bool isMinusZ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isZ)
        {
            transform.localEulerAngles = new Vector3(90, 0, 0);
        }
        else if (isMinusZ)
        {
            transform.localEulerAngles = new Vector3(-90, 0, 0);
        }
        else if (isX)
        {
            transform.localEulerAngles = new Vector3(0, 0, -90);
        }
        else if (isMinusX)
        {
            transform.localEulerAngles = new Vector3(0, 0, 90);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "player")
        {
            if (isZ)
            {
                Player.BoostType = 1;
            }
            else if (isMinusZ)
            {
                Player.BoostType = 2;
            }
            else if (isX)
            {
                Player.BoostType = 3;
            }
            else if (isMinusX)
            {
                Player.BoostType = 4;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            if (isZ)
            {
                Player.BoostType = 1;
            }
            else if (isMinusZ)
            {
                Player.BoostType = 2;
            }
            else if (isX)
            {
                Player.BoostType = 3;
            }
            else if (isMinusX)
            {
                Player.BoostType = 4;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "player")
        {
            Player.BoostType = 0;
        }
    }
}
