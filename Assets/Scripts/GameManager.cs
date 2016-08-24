using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	static public float gameSpeed;
	static public float difficulty;
	static public float health;
	static public float score;
	static public float lastScore;
	public float damageTime;
	public float lastDamage;
	static public int World;
	static public int lastWorld;
	private float reference=0.06f;
	public Color32 World1;
	public Color32 World2;
	public Color32 World3;
	public Color32 lastColor;
	public Color32 newColor;
	public GameObject background;
	public SpriteRenderer backgroundRenderer;
	static public bool canCreatures;
	static public bool canCreateAlgae;
	static public bool SlowDown;
    public bool ClickedReplayButton;
    public bool ClickedHomeButton;
    public GameObject GameOver;
    public GameObject GameOverBoxes;


    // Use this for initialization
    void Start () {
		backgroundRenderer = background.GetComponent<SpriteRenderer> ();
		health=100;
		damageTime=0.1f;
		Time.timeScale = 0;
		score=0;
		lastScore=0;
		gameSpeed=3;
		World=2;
		lastWorld=2;
		World2=new Color32(103,191,180,255);
		World1=new Color32(179,103,177,255);
		World3=new Color32(208,88,117,255);
		canCreatures=false;
		canCreateAlgae=false;
		SlowDown=false;



	}
	
	// Update is called once per frame
	void Update () {
		if (score > 100) {canCreatures = true;canCreateAlgae=true;}
		ChooseWorld ();
		changeBackgroundColor ();
		
		///////
		if (Input.GetKey (KeyCode.Space)||Input.touchCount > 0){Time.timeScale = 1;}
		//////
		gameSpeed=Mathf.Clamp(2*reference*Time.timeSinceLevelLoad,3,9.5f);
		//Debug.Log (score);
		if(Time.time-lastDamage>damageTime){
			health -= 1f;
			lastDamage = Time.time;
		}

		if (health == 0) {
            GameOver.SetActive(true);
            GameOverBoxes.SetActive(true);

            Time.timeScale = 0;
			if (ClickedReplayButton|| Input.touchCount > 0) {
				SceneManager.LoadScene("Game");
			}


            if (ClickedHomeButton) {

                SceneManager.LoadScene("StartScreen");
            }
		} else {
            GameOver.SetActive(false);
			score=Time.timeSinceLevelLoad *gameSpeed/5;
			score=Mathf.Round(score);
		}

	}
	void ChooseWorld(){
		if (score-lastScore==25){
			do {
			World=Random.Range(1,4);
			}while(World==lastWorld);
			lastScore=score;
			lastWorld=World;
			lastColor=newColor;
			Debug.Log (World);
		}
	}
	void changeBackgroundColor(){
		if(World==1){newColor = World1;}
		if(World==2){newColor = World2;}
		if(World==3){newColor = World3;}

	}
	void slowDown(){
		if (SlowDown) {

		}
	}

    public void Replay() {

        ClickedReplayButton = true;
    }
    public void Home() {

        ClickedHomeButton = true;
            }
}
