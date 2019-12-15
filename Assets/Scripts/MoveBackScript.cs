using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackScript : MonoBehaviour {

	private Rigidbody rb;
	private GameManager gameManager;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		gameManager = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		rb.MovePosition(transform.position - transform.forward * Time.fixedDeltaTime * gameManager.moveBackSpeed);
	}
}
