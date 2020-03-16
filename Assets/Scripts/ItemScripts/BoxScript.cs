using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour {
	private HealthManager healthManager;
	private GameManager gameManager;

	public TextMesh blockText;

	public int blockHealth = 3;

	public int minValue = 1;
	public int maxValue = 5;
	private int playerHealth;

	// Use this for initialization
	void Start () {
		gameManager = FindObjectOfType<GameManager>();
		healthManager = gameManager.GetComponent<HealthManager>();

		playerHealth = healthManager.currentHealth;
		minValue = Mathf.Clamp(Mathf.RoundToInt(playerHealth / 5), 1, 80);
		maxValue = Mathf.Clamp(Mathf.RoundToInt(playerHealth * 1.25f), 1, 80);


		blockHealth = Random.Range(minValue, maxValue);

		UpdateText();
	}

	void UpdateText()
	{
		blockText.text = blockHealth.ToString();
	}
}
