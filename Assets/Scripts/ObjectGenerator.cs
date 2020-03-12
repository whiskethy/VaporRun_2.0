using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour {

	public GameObject Block;
	public GameObject Node;
	public GameObject Wall;
	public Transform generationPoint;
	public float TubeRadius = 11.0f;
	private float xLocation;
	private float yLocation;
	public int wallSpawnRate = 5;
	public int nodeSpawnRate = 5;
	public int blockSpawnRate = 5;
	
	//private float zLocation;
	//private float zRotation;

	//private Vector3 rotationVect;

	private int creationNum;
	private int positionNum;

	// Use this for initialization
	void Start () {
		InvokeRepeating("MakeThings", .01f, .5f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//if(( this.transform.position.z < generationPoint.position.z ) && (generationPoint.position.z > 5.0f))
		//{
	
		//}
	}

	void MakeThings() 
	{
		for(int i = 0; i < 16; i++)
		{
			xLocation = 0.0f;
			yLocation = TubeRadius;

			this.transform.position = new Vector3(xLocation, yLocation, this.transform.position.z);

			transform.RotateAround(Vector3.zero, Vector3.forward, 22.5f * i);

			Factory();
			transform.RotateAround(Vector3.zero, Vector3.forward, -22.5f * i);

		}
	}


	private void Factory()
	{
			creationNum = Random.Range(0, 100);

			if(creationNum < blockSpawnRate){
				Instantiate(Block, this.transform.position, this.transform.rotation);
			}
			else if((creationNum >= 30) && (creationNum < (30 + nodeSpawnRate))){
				Instantiate(Node, this.transform.position, this.transform.rotation);
			}
			else if((creationNum >= 60) && (creationNum < (60 + wallSpawnRate))){
				Instantiate(Wall, this.transform.position, this.transform.rotation);
			}
			else
			{
				//do nothing
			}
	}


	public void IncreaseDifficulty()
	{
		
		if(wallSpawnRate < 16)
		{
			blockSpawnRate += 1;
			wallSpawnRate += 1;
		}
		if(nodeSpawnRate > 7)
		{
			nodeSpawnRate -= 1;
		}
	}

}
