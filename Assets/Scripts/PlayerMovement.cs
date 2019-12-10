using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //bursted cube values
    public float cubeSize = 0.2f;
    public int cubes = 5;
    public float burstForce = 50f;
    public float burstRadius = 4f;
    public float burstUpward = 0.4f;

    float cubesPivotDistance;
    Vector3 cubesPivot;

    public GameObject piecePrefab;
    public Rigidbody player;
    public bool grounded;

    public Animator animator;

    private void Start()
    {
       // player.AddForce(5, 0, 0);
        player = GetComponent<Rigidbody>();

        cubesPivotDistance = cubeSize * cubes / 2;
        cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);
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
            //rotate back
            transform.Rotate(Vector3.back * 5f);
        }

        if (player.transform.position.y < -3)
        {

            animator.SetTrigger("Fade1to2");
            //animate the new background to fade in, and the current to fade out.
        }

        if (player.transform.position.y < -10)
        {
            animator.SetTrigger("Fade2to3");
        }

    }
    // =========== COLLISIONS ==============
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Floor")
        {
            grounded = true;
        }
        if (collision.collider.tag == "Obstacle")
        {
            burst();
            SoundManagerScript.PlaySound ("crash");
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Floor")
        {
            grounded = false;
        }
    }

    // ============= BURST THE CUBE INTO PIECES =============
    public void burst()
    {
        // Destroy(player.gameObject);
        gameObject.SetActive(false);

        for (int x = 0; x < cubes; x++)
        {
            for (int y = 0; y < cubes; y++)
            {
                for (int z = 0; z < cubes; z++)
                {
                    createPiece(x, y, z);
                }
            }
        }
        Vector3 explosionPos = transform.position; //get explosion position
        Collider[] colliders = Physics.OverlapSphere(explosionPos, burstRadius);  //get colliders at position
        foreach (Collider hit in colliders)  //add explosion force
        {
            //get rigidbody from collider object
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                //add explosion force to rb
                rb.AddExplosionForce(burstForce, transform.position, burstRadius, burstUpward);
            }
        }
    }


    // ============ CREATE THE PIECES =============
    void createPiece(int x, int y, int z)
    {
        //create piece
        GameObject piece;
        piece = Instantiate(piecePrefab, new Vector3(0, 0, 0), Quaternion.identity);

        //set piece position and scale
        piece.transform.position = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z) - cubesPivot;
        piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);

        //add rigidbody and set mass
        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = cubeSize;
    }
}
