using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    // menyimpan button
    public KeyCode input;

    // untuk menyimpan hinge joint
    private HingeJoint hinge;

    // menyimpan angka target position saat ditekan dan dilepas
    private float targetPressed;
    private float targetRelease;

    // Use this for initialization
	void Start() 
	{
        // hinge joint disimpan saat start terlebih dahulu
        hinge = GetComponent<HingeJoint>();

        // saat Start, kita set kedua target tersebut
        targetPressed = hinge.limits.max;
        targetRelease = hinge.limits.min;
	}
	
	// Update is called once per frame
	void Update() 
	{
        // Read Input
        ReadInput();
	
        // Move Paddle
        MovePaddle();
	}

    private void ReadInput()
    {
        // langsung menggunakan variabel yang sudah dibuat saat Start
        JointSpring jointSpring = hinge.spring;
        
        // mengubah value spring saat input ditekan dan dilepas
        if (Input.GetKey(input))
        {
            //disini kita ganti menjadi mengubah target position
            jointSpring.targetPosition = targetPressed;
        }
        else
        {
            // disini kita ganti menjadi mengubah target release
            jointSpring.targetPosition = targetRelease;
        }
        
        // disni pun langsung menggunakan variabel
        hinge.spring = jointSpring;

    }

    private void MovePaddle()
    {
        // Move Paddle Here
    }
}
