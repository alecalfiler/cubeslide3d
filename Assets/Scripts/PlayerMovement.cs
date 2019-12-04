using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody player;
    public bool grounded;
    public Respawn respawnPoint;

    private void Start()
    {
        player.AddForce(5, 0, 0);
        player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 vel = player.velocity;
        vel.x = 5;
        player.velocity = vel;
   
        //rotation
        if (Physics.Raycast(transform.position, Vector3.down, GetComponent<BoxCollider>().size.y / 2 + 0.4f))
        {
            Quaternion rotate = transform.rotation;
            rotate.z = Mathf.Round(rotate.z / 90) * 90;
            transform.rotation = rotate;
            //jump
            if (Input.GetKey("space") && grounded == true)
            {
                player.velocity = Vector3.zero;
                player.AddForce(Vector3.up * 55000);
            }
        }
        else
        {
            transform.Rotate(Vector3.back * 5f);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Floor")
        {
            grounded = true;
        }
        if (collision.collider.tag == "Obstacle")
        {
            Debug.Log("We hit something");
            respawnPoint.RestartGame();
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
