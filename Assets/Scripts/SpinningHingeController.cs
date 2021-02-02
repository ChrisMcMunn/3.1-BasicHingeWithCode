using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Make sure the GameObject this script is attached to also has a 
// HingeJoint2D component attached. If not, one will get attached
// (along with a Rigidbody2D component as all Joint2D components
// need them)).
[RequireComponent(typeof(HingeJoint2D))]

public class SpinningHingeController : MonoBehaviour
{
    // Reference to various components on the GameObject that the
    // script needs to access
    private HingeJoint2D hinge;
    private Rigidbody2D rigidBody;

    private void Awake()
    {
        // Initialise the rigidBody and hinge variables (saves me having to "wire them
        // up" via the inspector)
        hinge = GetComponent<HingeJoint2D>();
        rigidBody = GetComponent<Rigidbody2D>();

        // Initially I am going to turn off the use of the motor
        hinge.useMotor = false;
    }

    /* 
     * You can set the default motor speed in the HingeJoint2D component via the
     * inspectir but this method below allows the LevelManager (or another object)
     * to set it to something else if it so wishes.
     */
    public void SetHingeMotorSpeed(float desiredSpeed)
    {
        /*
         * Information about Joint2D components is available in the
         * manual here https://docs.unity3d.com/Manual/Joints2D.html
         * 
         */

        // Scripting API for HingeJoint2D https://docs.unity3d.com/ScriptReference/HingeJoint2D.html

        /*
         * The HingeJoint2D component contains a JointMotor2D component. When components
         * contain other components that you want to modify you typically need to
         * save a copy of the component you want to modify in a local variable, change
         * the copy store in the local variable, then save the modified local copy
         * back onto the original component.
         * 
         * Below I:
         *  - take a copy of the JointMotor2D component from the HingeJoint2D componet
         *  - change its motorSpeed property
         *  - save the modified JointMotor2D component back onto the HingeJoint2D componet
         */
        JointMotor2D hingeMotor = hinge.motor;
        hingeMotor.motorSpeed = desiredSpeed;
        hinge.motor = hingeMotor;
    }

    public void ToggleSpinningHingeMotor()
    {
        /*
         * If the useMotor property if the HingeJoint2D component is set to true then
         * set it to false and visa versa.
         */
        if (hinge.useMotor == true)
        {
            hinge.useMotor = false;

            // It's not enough to turn the motor off, we also need to stop it spinning
            // by setting its angular velocity to 0
            rigidBody.angularVelocity = 0f;
        }
        else
        {
            hinge.useMotor = true;
        }
    }
}
