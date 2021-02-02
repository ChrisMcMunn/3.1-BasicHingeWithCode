using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * The following two lines ensure that the GameObject this script is attached to
 * has a SpringJoint2D component, if it doesn't Unity automatically puts one on.
 */
[RequireComponent(typeof(SpringJoint2D))]
public class SpringController : MonoBehaviour
{
    // Reference to various components on the GameObject that the
    // script needs to access
    private Rigidbody2D rigidBody;

    private void Awake()
    {
        // Initialise the rigidBody variable (saves me having to "wire it
        // up" via the inspector)
        rigidBody = GetComponent<Rigidbody2D>();

    }

    /*
     * Notice that the following function takes in a Vector2 argument called
     * theForceToApply. Whoever calls this function is going to have to pass
     * this function a Vector2 object representing "the force to apply".
     */
    public void ApplyForceToSpring(Vector2 theForceToApply)
    {
        // To apply a force to a GameObject we have to apply that force to
        // the RigidBody component of that GameObject
        rigidBody.AddForce(theForceToApply);
    }
}
