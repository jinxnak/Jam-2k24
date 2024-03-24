using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    private Animator animator;
    private bool run = false;
    private bool isDead = false;

    public bool IsDead { get { return isDead; } set { isDead = value; } }
    Vector3 axis;
    [SerializeField] private float speed = 6f;
    public Vector3 resetPos;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        PlayerInput();
        animate();
        rotate();
        animator.SetBool("state", run);
    }

    private void animate()
    {
        if (axis.x > 0f || axis.z > 0f || axis.x < -0f || axis.z < -0f) {
            run = true;
        } else {
            run = false;
        }
    }
    private void PlayerInput() {
        axis = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        Debug.Log(axis);
    }
    private void rotate() {
        // Vector3 newDirection = Vector3.RotateTowards(transform.forward, axis, 10f, 0.0f);
        // transform.rotation = Quaternion.LookRotation(newDirection);
         if (axis != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(axis, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 720 * Time.deltaTime);            
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = axis * speed;
    }

    public void resetPlayer()
    {
        gameObject.transform.position = resetPos;
        gameObject.SetActive(true);
    }
}

 