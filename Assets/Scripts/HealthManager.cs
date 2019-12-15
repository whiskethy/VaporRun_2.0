using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthManager : MonoBehaviour {

	 public TextMeshPro playerHealthText;
	public int currentHealth = 0;
	public int startingHealth = 5;

	public GameObject playerObject;
	private GameManager gameManager;
	// Use this for initialization
	void Start () {
		currentHealth = startingHealth;
		gameManager = this.GetComponentInParent<GameManager>();
		UpdatePlayerHealth();
	}
	
	void UpdatePlayerHealth()
	{
		playerHealthText.text = currentHealth.ToString();
	}

	public void TakeDamage(int damage)
	{
		currentHealth = currentHealth - damage;
		
		if(currentHealth <= 0)
		{
			gameManager.KillPlayer();
		}

		UpdatePlayerHealth();
	}

	public void GiveHealth(int health)
	{
		currentHealth = currentHealth + health;

		UpdatePlayerHealth();
	}
}
