using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthNodeScript : MonoBehaviour {
	private HealthManager healthManager;
	private GameManager gameManager;

	public TextMesh nodeText;
	public int nodeHealth = 3;
	public int minValue = 1;
	public int maxValue = 5;
	private int playerHealth;


	// Use this for initialization
	void Start () {
		gameManager = FindObjectOfType<GameManager>();
		healthManager = gameManager.GetComponent<HealthManager>();

		playerHealth = healthManager.currentHealth;
		minValue = Mathf.Clamp(Mathf.RoundToInt(playerHealth / 2), 3, 30);
		maxValue = Mathf.Clamp(Mathf.RoundToInt(playerHealth * .75f), 7, 30);

		nodeHealth = Random.Range(minValue, maxValue);

		UpdateText();
	}
	
	void UpdateText()
	{
		nodeText.text = nodeHealth.ToString();
	}
}
