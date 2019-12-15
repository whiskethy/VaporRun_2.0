using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerDeath : MonoBehaviour
{
    private GameManager gameManager;
   	public HealthManager healthManager;
    public GameObject warpLines;
    public GameObject worldWarpLines;
    public GameObject model;
    public TextMeshPro healthText;
    public GameObject explosionEffect;
    public void KillPlayer()
    {
        gameManager = FindObjectOfType<GameManager>();
        this.GetComponent<MeshRenderer>().enabled = false;
        Destroy(warpLines);
        Destroy(worldWarpLines);
        Destroy(healthText);
        gameManager.audioManager.PlaySound("PlayerDeath");
        Instantiate(explosionEffect, this.transform.position, Quaternion.identity);
		model.GetComponent<MeshRenderer>().enabled = false;
    }
}
