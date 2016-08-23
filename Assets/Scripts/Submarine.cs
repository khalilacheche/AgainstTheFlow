using UnityEngine;
using System.Collections;

public class Submarine : MonoBehaviour {
    // Use this for initialization
    static public bool shaker = true;

    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnBecameInvisible()
    {
        enabled = false;
        Submarine.shaker = false;

    }
    void OnBecameVisible()
    {
        enabled = true;
    }
}
