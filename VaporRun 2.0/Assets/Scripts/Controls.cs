using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {

	//public Animator anim;
	private GameManager gameManager;
	public Joystick joystick;
	public GameObject model;

	float movement = 0f;	
	void Start()
	{
		gameManager = FindObjectOfType<GameManager>();
	}

	// Update is called once per frame
	void Update () {
		//movement = Input.GetAxisRaw("Horizontal") * gameManager.playerMoveSpeed;
		if(joystick.Horizontal >= .2f)
		{
			//anim.SetBool("isFlyingRight", true);
			//anim.SetBool("isFlyingLeft", false);
			movement = joystick.Horizontal * gameManager.playerMoveSpeed;
		}
		else if(joystick.Horizontal <= -.2f)
		{
			//anim.SetBool("isFlyingLeft", true);
			//anim.SetBool("isFlyingRight", false);
			movement = joystick.Horizontal * gameManager.playerMoveSpeed;
		}
		else
		{
			//anim.SetBool("isFlyingRight", false);
			//anim.SetBool("isFlyingLeft", false);
			movement = 0f;
		}
		
	}
	private void FixedUpdate()
	{
		transform.RotateAround(Vector3.zero, Vector3.forward, -movement * Time.fixedDeltaTime);
		//transform.Rotate(new Vector3(0f, movement * Time.fixedDeltaTime * gameManager.playerMoveSpeed, 0f), Space.Self);
	}
}
