using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    public SpinningHingeController spinningHinge;
    public SpringController spring;
    public PivotHingeController pivotHinge;

    public float pivotMotorDownSpeed = 10f;
    public float pivotMotorUpSpeed = 10f;

    // A static instance variable just in case other scripts need to
    // access the LevelManager
    public static LevelManager instance;

    private void Awake()
    {
        /*
         * check if the instance variable is null, which it will be for the
         * first (and possibly onlu) LevelManager script object created, and 
         * if it is set it to this object.
         */
        if (instance == null)
        {
            instance = this;
        }

        /*
         * Check to see if the following instance variables are null, which
         * they will be if they weren't 'wired up' via the inspector, and if
         * so print out a warning message.
         */
        if (spinningHinge == null || spring == null || pivotHinge == null)
        {
            Debug.LogWarning("One or more of the public properties on the LevelManager is null");
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.S))
        {
            spinningHinge.ToggleSpinningHingeMotor();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            pivotHinge.SetPivotHingeMotorSpeed(pivotMotorDownSpeed);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            pivotHinge.SetPivotHingeMotorSpeed(pivotMotorUpSpeed * -1);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            // A force that is 55 newtons directly up.
            Vector2 aForce = new Vector2(0, 500);

            spring.ApplyForceToSpring(aForce);
        }
    }

    
}
