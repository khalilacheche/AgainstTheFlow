using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneManagerP : MonoBehaviour {
	public GameObject[] UI;
	public Camera MainCam;
	public GameObject Player;
    public GameObject SubTailP;
    public GameObject WaveOne;
    public GameObject WaveTwo;
	private Animator PlayerAnim;
	static public bool ClickedStartButton;
	public bool ClickedOptionsButton;
	public bool finishedRotating=false;
    public Rigidbody2D PlayerRigid;
    public float translationSpeedx;
    public float translationSpeedy;


    [SerializeField]

    public GameObject fadera;


    


    
    void start()
    {
    
    }


    //public GameObject WarningBubble;
    void Update () {
        PlayerRigid = Player.GetComponent<Rigidbody2D>();
        if (fadera.GetComponent<SpriteRenderer>().color.a == 1)
        {
            SceneManager.LoadScene("SpermoPlay");
        }
        if (ClickedStartButton == true) {
            if (GetTheFishBack.fadeBool == true)
            {
                fadera.GetComponent<Animator>().SetBool("makeit", true);

            }

            else if (GetTheFishBack.fadeBool == false)
            {
                fadera.GetComponent<Animator>().SetBool("makeit", false);
                
            }
            


            //Translation buttons
            for (int i = 0; i < 2; i++) {
				UI [i].transform.Translate (18f, 0f, 0f);
                
			}
            // Translation LOGO Right Cloud
            UI[2].transform.Translate(0.0f, 0.04f, 0f);
            UI[5].transform.Translate(0.05f, 0f, 0f);

            //translate left and middle cloud
            for (int i = 3; i < 5; i++)
            {
                UI[i].transform.Translate(-0.05f, 0f, 0f);
            }
            //
            
            PlayerRigid.velocity = new Vector2(translationSpeedx, translationSpeedy);
            
           


            //naarach hedhi chniya
            Player.GetComponent<Animator> ().enabled = false;
            //

            //Desables  waves animations when start button is clicked
            WaveOne.GetComponent<Animator>().enabled = false;
            WaveTwo.GetComponent<Animator>().enabled = false;
            //

            //WarningBubble.SetActive (true);



        }





        //Translation to the options menu
		if (ClickedOptionsButton == true) {
			for (int i = 0; i < UI.Length; i++) {
				UI [i].transform.Translate (18f, 0f, 0f);
			}
			if (MainCam.transform.position.y <= 9.91f) {
				MainCam.transform.Translate (0f, 0.1f, 0f);
			}
		}
        //

        //dunno what this is
		if (finishedRotating) {

			if (Player.transform.position.y >= -9.26) {
				Player.transform.Translate (0.05f, 0f, 0f);
			}
			if (MainCam.transform.position.y >= -12.06f) {
				MainCam.transform.Translate (0f, 0.1f, 0f);
			}
		}
        //


	
	}
	public void StartButton() {
		ClickedStartButton = true;

	}

	public void OptionsButton () {

		ClickedOptionsButton = true;
	}

	IEnumerator WaitForSeconds() {
		yield return new WaitForSeconds (1);
	}


}
