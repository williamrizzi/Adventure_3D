using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    private float x;
    private float y;

    [SerializeField]
    [Range(0f, 10f)]
    private float speed;

    [SerializeField]
    [Range(0f, 30f)]
    private float jumpForce;

    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private Animator anim;

    [SerializeField]
    private bool isGrounded;

    public Transform[] list;


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        anim = gameObject.GetComponentInChildren<Animator>();

        isGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        switch (GetComponent<Rotate_Script>().Direction)
        {
            case 0:
                rb.velocity = new Vector3(x * speed, rb.velocity.y, y * speed);
                break;
            case 1:
                rb.velocity = new Vector3(y * speed, rb.velocity.y, -x * speed);
                break;
            case 2:
                rb.velocity = new Vector3(-x * speed, rb.velocity.y, -y * speed);
                break;
            case 3:
                rb.velocity = new Vector3(-y * speed, rb.velocity.y, x * speed);
                break;
        }

        if(Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {                
                anim.SetBool("jumping", true);
                rb.velocity += Vector3.up * jumpForce;
                isGrounded = false;
            }            
        }

        if (x != 0 || y != 0)
        {
            anim.SetBool("walking", true);
            if (x < 0)
            {
                GetComponentInChildren<SpriteRenderer>().flipX = true;
            }
            else if (x > 0)
            {
                GetComponentInChildren<SpriteRenderer>().flipX = false;
            }
        }
        else
        {
            anim.SetBool("walking", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Ground")
        {
            isGrounded = true;
            anim.SetBool("jumping", false);
            anim.SetBool("falling", false);
        }        
    }

}
