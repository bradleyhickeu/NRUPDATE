using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Events;

public class GameControl : MonoBehaviour {
	public int Health = 100;
	public int Ammo = 0;
	public int Reserve = 0;
	public Vector2 pos = new Vector2 (210,10);
	public Vector2 size = new Vector2 (550,40);
	public Texture2D emptyHealth;
	public Texture2D fullHealth;
	public Text AmmoText;
	public Text ReserveText;
	public GameObject Panel;
	private bool gamePaused = false;



	public static GameControl control;

	// Use this for initialization
	void Start () {
		if (control == null) {
			//create a new game controller and attach script if non existent.
			DontDestroyOnLoad (gameObject);
			control = this;

		} else if (control != this) {
			//destroy if contorl exists
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)){
			TogglePause ();
			
		}
		AmmoText.text ="Ammo:" + Ammo ;
		ReserveText.text = "Reserve:" + Reserve;
	
	}

	/*void OnGUI()
	{
		GUI.Label (new Rect (10, 10, 100, 50), "Health:" + Health);
		GUI.Label (new Rect (10, 20, 100, 50), "Ammo:" + Ammo);
		GUI.Label (new Rect (10, 30, 100, 50), "Reserve:" + Reserve);

		GUI.BeginGroup(new Rect(pos.x,pos.y,size.x,size.y));
		GUI.DrawTexture (new Rect (0, 0, size.x, size.y), emptyHealth);

		GUI.BeginGroup(new Rect(0,0,size.x*Health/100,size.y));
		GUI.DrawTexture (new Rect (0, 0, size.x, size.y), fullHealth);


		GUI.EndGroup ();
		GUI.EndGroup ();


	}
*/





	public void ChangeHealth(int damage){
		Health += damage;
		if (Health < 0) {
			Health = 0;		
		}
		if (Health > 100) {
			Health = 100;		
		}
	}

	public void ChangeAmmo(int difference){
		Ammo += difference;
		if (Ammo < 0) {
			Ammo = 0;		
		}

	}

	public int ChangeReserve(int amount){
		Debug.Log ("amount called for :"+amount);
		if (amount > Reserve) {
			Debug.Log ("amount given a:"+Reserve);
			return Reserve;

			Reserve -= Reserve;

		} else {
			Debug.Log ("amount given b :"+amount);
			Reserve -= amount;
			return amount;

		}



	}

	public void TogglePause(){
		//function to show pause menu and prevent game play and reactivate it
		//check if game is paused and unpause it.
		if (gamePaused){
			Debug.Log ("unpause game");
			Time.timeScale = 1;
		}

		//check if game is unpaused, and pause it
		if (!gamePaused){
			Debug.Log ("pause game");
			Time.timeScale = 0;
		}





	}
}
