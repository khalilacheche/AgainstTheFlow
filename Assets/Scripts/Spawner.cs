using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {
	public GameObject Obstacle;
	public GameObject Pill;
	public float xRight;
	public float yRight;
	public float xLeft;
	public float yLeft;
	public bool Boolean ;
	static public bool canCreate=true;
	public  static GameObject spawnedObstacle;
	public GameObject Algae;
	public GameObject ob1m1;
	public GameObject ob2m1;
	public GameObject ob3m1;
	public GameObject ob1m2;
	public GameObject ob2m2;
	public GameObject ob3m2;
	public GameObject ob1m3;
	public GameObject ob2m3;
	public GameObject ob3m3;
	public GameObject Creat1;
	public GameObject Creat2;
	public GameObject Creat3;
	public List <GameObject> Creatures;
	public List <GameObject> World1;
	public List <GameObject> World2;
	public List <GameObject> World3;
	// Use this for initialization
	void Start () {
		GameManager.difficulty = 0.75f;
		InvokeRepeating ("spawnPill",Random.Range(5,8),3);
		InvokeRepeating ("spawnAlgae",Random.Range(10,20),10);
		InvokeRepeating ("spawnObstacle", 1f, 1f);
		InvokeRepeating ("spawnCreatures",Random.Range(6,9), 4f);
		canCreate=true;
		World1 = new List<GameObject> ();
		World2 = new List<GameObject> ();
		World3 = new List<GameObject> ();
		Creatures = new List<GameObject> ();

		World1.Add (ob1m1);
		World1.Add (ob2m1);
		World1.Add (ob3m1);
		World2.Add (ob1m2);
		World2.Add (ob2m2);
		World2.Add (ob3m2);
		World3.Add (ob1m3);
		World3.Add (ob2m3);
		World3.Add (ob3m3);

		Creatures.Add (Creat1);
		Creatures.Add (Creat2);
		Creatures.Add (Creat3);

	}
	
	// Update is called once per frame
	void Update () {
	}
	void spawnPill(){
		Instantiate (Pill, new Vector2(Random.Range(xLeft+0.5f,xRight-0.5f),10),Quaternion.identity);
	}

	void spawnObstacle(){
		Boolean= (Random.value > 0.5f);
		if (canCreate) {
			if (Boolean) {
				spawnObstacleRight ();
			} else {
				spawnObstacleLeft ();
			}
			canCreate=false;
		}
	}
	void spawnObstacleRight(){
		if(GameManager.World==1){
			spawnedObstacle = Instantiate (World1[Random.Range(0,3)], new Vector2 (xRight, yRight), Quaternion.identity) as GameObject;	
		}
		else if(GameManager.World==2){
			spawnedObstacle = Instantiate (World2[Random.Range(0,3)], new Vector2 (xRight, yRight), Quaternion.identity) as GameObject;	
		}
		else if(GameManager.World==3){
			spawnedObstacle = Instantiate (World3[Random.Range(0,3)], new Vector2 (xRight, yRight), Quaternion.identity) as GameObject;	
		}
		if (spawnedObstacle != null) {
			spawnedObstacle.transform.localScale = new Vector3 (transform.localScale.x * Random.Range (0.75f, 1.25f), transform.localScale.y * Random.Range (0.75f, 1.1f), transform.localScale.z);
			spawnedObstacle.transform.rotation = Quaternion.Euler (transform.rotation.x, transform.rotation.y, 90);
			}
		}
	void spawnObstacleLeft(){
		if(GameManager.World==1){
			spawnedObstacle = Instantiate (World1[Random.Range(0,3)], new Vector2 (xLeft, yLeft), Quaternion.identity) as GameObject;	
		}
		else if(GameManager.World==2){
			spawnedObstacle = Instantiate (World2[Random.Range(0,3)], new Vector2 (xLeft, yLeft), Quaternion.identity) as GameObject;
		}
		else if(GameManager.World==3){
			spawnedObstacle = Instantiate (World3[Random.Range(0,3)], new Vector2 (xLeft, yLeft), Quaternion.identity) as GameObject;
		}
		if(spawnedObstacle!=null){
			spawnedObstacle.transform.localScale = new Vector3 (transform.localScale.x * Random.Range (0.75f, 1.25f), -transform.localScale.y * Random.Range (0.75f, 1.1f), transform.localScale.z);
		spawnedObstacle.transform.rotation = Quaternion.Euler (transform.rotation.x, transform.rotation.y, 90);
	
		}
	}
	void spawnCreatures(){
		if(GameManager.canCreatures){
		Instantiate (Creatures[Random.Range(0,3)], new Vector2(Random.Range(xLeft+0.5f,xRight-0.5f),10),Quaternion.identity);
		}
	}
	void spawnAlgae(){
		if(GameManager.canCreateAlgae){
			Instantiate (Algae, new Vector2(Random.Range(xLeft+0.5f,xRight-0.5f),10),Quaternion.identity);
		}
	}
}
