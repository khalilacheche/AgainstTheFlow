using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;

public class PillBehave : MonoBehaviour {
	public Rigidbody2D PillRigidBody;
	public Transform PillTransform;
	public float yscale;
	// Use this for initialization
	void Start () {
		PillRigidBody = GetComponent<Rigidbody2D> ();
		PillTransform = GetComponent<Transform> ();

	}
	
	// Update is called once per frame
	void Update () {
		PillRigidBody.velocity =new Vector2(PillRigidBody.velocity.x, -GameManager.gameSpeed) ;
		PillTransform.Rotate (0, 0, 100 * Time.deltaTime);
		if (gameObject.GetComponent<Renderer> ().isVisible)
		{
		}
		else 
		{
			//Destroy (gameObject);
		}
	}
	void OnTriggerEnter2D(Collider2D trig){
		if (trig.gameObject.tag=="Player"){
			Destroy (gameObject);
            GameManager.health += 20;
		}
		if (trig.gameObject.tag=="Destroyer"){
			Destroy (gameObject);
		}

	}
	void OnTriggerStay2D(Collider2D stay){
		if (stay.gameObject.tag == "Obstacle") {
			gameObject.transform.Translate(new Vector2(0,2));
		}

	}
}
