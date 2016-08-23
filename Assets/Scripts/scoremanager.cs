using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class scoremanager : MonoBehaviour {

    public Text OldScore;
    public Text NewScore;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        NewScore.text = OldScore.text;

	}
}
