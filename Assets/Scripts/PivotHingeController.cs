using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HingeJoint2D))]

public class PivotHingeController : MonoBehaviour
{
    // Reference to various components on the GameObject that the
    // script needs to access
    private HingeJoint2D hinge;

    private void Awake()
    {
        // Initialise the hinge variable (saves me having to "wire it
        // up" via the inspector)
        hinge = GetComponent<HingeJoint2D>();
    }


    public void SetPivotHingeMotorSpeed(float speedToSet)
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
        JointMotor2D theMotor = hinge.motor;
        theMotor.motorSpeed = speedToSet;
        hinge.motor = theMotor;
    }
}
