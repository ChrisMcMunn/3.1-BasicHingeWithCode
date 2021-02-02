using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    
    // Reference to various components on the GameObject that the
    // script needs to access
    private Rigidbody2D rigidBody;
    private Animator animator;

    // Various variables the script needs to store "state"
    public float horizontalSpeed = 100f;
    private bool facingRight = true;

    private void Awake()
    {
        // Initialise the rigidBody and animator variables (saves me having to "wire 
        // them up" via the inspector)
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            FaceRight();
            rigidBody.velocity = Vector2.right * horizontalSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            FaceLeft();
            rigidBody.velocity = Vector2.left * horizontalSpeed * Time.deltaTime;
        }
        else
        {
            rigidBody.velocity = Vector2.zero;
        }
    }

    /*
     * Just to demonstrate how you can animate properties of a GameObject like for
     * example localScale, I created an Animator Controller with some Animations
     * to do just that. The transitions between the Animations are triggered using
     * the Animator Trigger property called "turn".
     */
    void FaceRight()
    {
        if (facingRight == false)
        {
            animator.SetTrigger("turn");
            facingRight = true;
        }
    }

    void FaceLeft()
    {
        if (facingRight == true)
        {
            animator.SetTrigger("turn");
            facingRight = false;
        }
    }
}
