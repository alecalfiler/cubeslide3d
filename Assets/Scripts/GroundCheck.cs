using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject Player;
    void Start()
    {
        Player = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Floor")
        {
            Debug.Log("Dick");
            Player.GetComponent<PlayerMovement>().grounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Floor")
        {
            Player.GetComponent<PlayerMovement>().grounded = false;
        }
    }
}
