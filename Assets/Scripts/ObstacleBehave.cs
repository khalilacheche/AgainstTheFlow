using UnityEngine;
using System.Collections;

public class ObstacleBehave : MonoBehaviour {
	public Rigidbody2D ObstacleRigidBody;
//	public  Transform cameraPosition;
	// Use this for initialization
	void Start () {
		ObstacleRigidBody = GetComponent<Rigidbody2D> ();
		GameManager.gameSpeed=5f;

	}

	// Update is called once per frame
	void Update () {
		ObstacleRigidBody.velocity =new Vector2(ObstacleRigidBody.velocity.x, -GameManager.gameSpeed) ;
		}

	void OnTriggerEnter2D(Collider2D trig){
		if (trig.gameObject.tag=="Destroyer"){
			Destroy (gameObject);
		}
	}

    void OnCollisionEnter2D (Collision2D col)
    {
        if(col.gameObject.tag =="Player")
        {
            GameManager.health = 0f;

        }

    }
}

