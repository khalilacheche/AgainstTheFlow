using UnityEngine;
using System.Collections;

public class ObstacleBehave : MonoBehaviour {
	public Rigidbody2D ObstacleRigidBody;

	void Start () {
		ObstacleRigidBody = GetComponent<Rigidbody2D> ();
		GameManager.gameSpeed=5f;

	}
		
	void Update () {
		////Moving the Obstacles
		ObstacleRigidBody.velocity =new Vector2(ObstacleRigidBody.velocity.x, -GameManager.gameSpeed) ;
		}


	void OnTriggerExit2D(Collider2D trig){
		///////Destroying the Game Object
		if (trig.gameObject.tag=="Destroyer"){
			Destroy (gameObject);
		}
	}
}

