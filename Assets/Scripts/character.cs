using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class character : MonoBehaviour
{
    float moveSpeed = 5;
    float jumpHeight = 5;
    bool Grounded;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Grounded = true;
    }

    // Update is called once per frame
    void Update()
    {
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
        if (Input.GetKeyDown(KeyCode.Space) && Grounded)
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            Grounded = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Plane"))
		{
            Grounded = true;
		}
	}
}
