using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class character : MonoBehaviour
{
    float moveSpeed = 10;
    float jumpHeight = 5;
    bool Grounded;
    Rigidbody rb;
    public Animator player;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Grounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        if (Input.GetKey(KeyCode.W))
		{
            transform.position += transform.forward * Time.deltaTime * moveSpeed;
            transform.rotation = Quaternion.Euler(0, 0, 0);
		}
        if (Input.GetKey(KeyCode.A))
		{
            transform.position += transform.forward * Time.deltaTime * moveSpeed;
            transform.rotation = Quaternion.Euler(0, 270, 0);
		}
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += transform.forward * Time.deltaTime * moveSpeed;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.forward * Time.deltaTime * moveSpeed;
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0, -45, 0);
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0, 45, 0);
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0, -135, 0);
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0, 135, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space) && Grounded)
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            Grounded = false;
        }

        //Walk Button Press Check
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            player.SetBool("BoolWalk", true);
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            player.SetBool("BoolWalk", false);
        }

        //Jump Button Press Check
        if (Input.GetKey(KeyCode.Space))
        {
            player.SetBool("BoolJump", true);
        }

        if (player.transform.position.y < -3)
		{
           SceneManager.LoadScene("Lose");
		}
    }
    private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Plane"))
		{
            Grounded = true;
            player.SetBool("BoolJump", false);
		}

        if(collision.gameObject.CompareTag("Goal"))
		{
            SceneManager.LoadScene("Win");
		}
	}
}
