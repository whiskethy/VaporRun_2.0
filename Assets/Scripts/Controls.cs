using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {

	//public Animator anim;
	private GameManager gameManager;
	public Animator anim;
	
	//public enum turningDirection = {left,center,right};
	//public Joystick joystick;
	public GameObject model;

	float movement = 0f;	
	void Start()
	{
		gameManager = FindObjectOfType<GameManager>();
	}

	// Update is called once per frame
	void Update () {
		
		// if(joystick.Horizontal >= .2f)
		// {
		// 	//anim.SetBool("isFlyingRight", true);
		// 	//anim.SetBool("isFlyingLeft", false);
		// 	movement = joystick.Horizontal * gameManager.playerMoveSpeed;
		// }
		// else if(joystick.Horizontal <= -.2f)
		// {
		// 	//anim.SetBool("isFlyingLeft", true);
		// 	//anim.SetBool("isFlyingRight", false);
		// 	movement = joystick.Horizontal * gameManager.playerMoveSpeed;
		// }
		// else
		// {
		// 	//anim.SetBool("isFlyingRight", false);
		// 	//anim.SetBool("isFlyingLeft", false);
		// 	movement = 0f;
		// }

		movement = Input.GetAxis("Horizontal") * gameManager.playerMoveSpeed;
		
		
	}
	private void FixedUpdate()
	{
		transform.RotateAround(Vector3.zero, Vector3.forward, -movement * Time.fixedDeltaTime);
		Debug.Log(movement);
		if(movement == 0)
		{
			anim.SetBool("isTurning", false);
			anim.SetInteger("turningDir", 0);
		}
		else if(movement < 0)
		{
			anim.SetBool("isTurning", true);
			anim.SetInteger("turningDir", -1);
		}
		else if(movement > 0)
		{
			anim.SetBool("isTurning", true);
			anim.SetInteger("turningDir", 1);
		}
		//transform.Rotate(new Vector3(0f, movement * Time.fixedDeltaTime * gameManager.playerMoveSpeed, 0f), Space.Self);
	}
}
