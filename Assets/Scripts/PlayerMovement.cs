using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody player;
    public bool grounded;

    private void Start()
    {
        player.AddForce(5, 0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 vel = player.velocity;
        vel.x = 5;
        player.velocity = vel;
   
        //rotation
        if (Physics.Raycast(transform.position, Vector3.down, GetComponent<BoxCollider>().size.x / 2 + 0.4f))
        {
            Quaternion rotate = transform.rotation;
            rotate.x = Mathf.Round(rotate.x / 90) * 90;
            transform.rotation = rotate;
            //jump
            if (Input.GetKey("space") && grounded == true)
            {
                
                player.AddForce(0, 300, 0);
            }
        }
        else
        {
            transform.Rotate(Vector3.back * 5f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Floor")
        {
            grounded = true;
        }
        if (collision.collider.tag == "Obstacle")
        {
            Debug.Log("We hit something");
            Destroy(player.gameObject);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Floor")
        {
            grounded = false;
        }
    }
}
