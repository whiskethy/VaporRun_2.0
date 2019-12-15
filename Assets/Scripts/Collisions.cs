using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collisions : MonoBehaviour {
//TODO: Move collision behavior to objects themselves
	private GameManager gameManager;
	public ScoreManager scoreManager;

	private HealthManager healthManager;

	private BoxScript box;
	private HealthNodeScript node;
	void Start()
	{
		gameManager = FindObjectOfType<GameManager>();
		healthManager = gameManager.GetComponent<HealthManager>();
		scoreManager = gameManager.GetComponent<ScoreManager>();
	}

	void OnCollisionEnter(Collision collision)
    {

		if(collision.gameObject.tag == "Block")
		{
			//Debug.Log("You hit a block");
			box = collision.gameObject.GetComponent<BoxScript>();
			//gameManager.audioManager.PlaySound("BlockBreak");
			healthManager.TakeDamage(box.blockHealth);

			scoreManager.AddPoints(box.blockHealth * 10);
        	Destroy(collision.gameObject);
			
		}
		else if(collision.gameObject.tag == "HealthNode")
		{
			//Debug.Log("You hit a healthNode");

			node = collision.gameObject.GetComponent<HealthNodeScript>();
			//gameManager.audioManager.PlaySound("NodePickup");
			healthManager.GiveHealth(node.nodeHealth);
			Destroy(collision.gameObject);
		}
		else if (collision.gameObject.tag == "Wall")
		{
			Debug.Log("You hit a wall");
			gameManager.KillPlayer();
		}
		else
		{

		}
    }
}
