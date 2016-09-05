using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	static public float gameSpeed;
	static public float difficulty;
	static public float health;
	static public float score;
	static public float lastScore;
	static public bool canCreatures;
	static public bool canCreateAlgae;
	static public bool SlowDown;
	static public int World;
	static public int lastWorld;
	private float reference=0.06f;
	private float damageTime;
	private float lastDamage;
	public GameObject background;
	public SpriteRenderer backgroundRenderer;
    public Text HighScore;
    public bool ClickedReplayButton;
	public bool ClickedHomeButton;
	public GameObject GameOver;


    // Use this for initialization
    void Start () {
		backgroundRenderer = background.GetComponent<SpriteRenderer> ();
		health=150;
		damageTime=0.1f;
		Time.timeScale = 0;
		score=0;
		lastScore=0;
		gameSpeed=3;
		World=2;
		lastWorld=2;
		canCreatures=false;
		canCreateAlgae=false;
		SlowDown=false;

	}
	
	// Update is called once per frame
	void Update () {

        /////////////////Health Clamping
        health = Mathf.Clamp(health,0,150);
	/////////////////Choosing to create Bonuses and Maluses
		if (score > 100) {canCreatures = true;canCreateAlgae=true;}
		////////////////Invoking functions
		ChooseWorld ();
	///////////Playing Game after first press
		if (Input.GetKey (KeyCode.Space)||Input.touchCount > 0){Time.timeScale = 1;}

        ///////////
        gameSpeed = Mathf.Clamp(2*reference*Time.timeSinceLevelLoad,3,9.5f);
	////////////Damaging
		if(Time.time-lastDamage>damageTime){
			health -= 1f;
			lastDamage = Time.time;
		}

        //GameOver 
		if (health == 0) {
            //Displaying GameOver UI
            GameOver.SetActive(true);
            //
            //Saving High Score 
            if (PlayerPrefs.GetFloat("HighScore") < score)
            {
                PlayerPrefs.SetFloat("HighScore", score);
            }
            if (HighScore != null)
            {
                HighScore.text = "Highscore : " + PlayerPrefs.GetFloat("HighScore").ToString();
            }

        }
        else {
            		
			score=Time.timeSinceLevelLoad *gameSpeed/5;
			score=Mathf.Round(score);
		}

        

        if (ClickedReplayButton || Input.touchCount > 0)
        {
            SceneManager.LoadScene("Game");
        }
        if (ClickedHomeButton)
        {
            SceneManager.LoadScene("StartScreen");
        }

    }
	void ChooseWorld(){
		if (score-lastScore==5){
			do {
			World=Random.Range(1,4);
			}while(World==lastWorld);
			lastScore=score;
			lastWorld=World;
			Debug.Log (World);
		}
	}
	

    public void Replay() {

        ClickedReplayButton = true;
    }
    public void Home() {

        ClickedHomeButton = true;
    }
}
