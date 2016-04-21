using UnityEngine;
using System.Collections;


public class GunScript : MonoBehaviour {
	//gun customizable aspects
	public GameObject playerGameStatControl;
	//shoting range
	public float gunRange =50f;
	//recoil kick
	public float maxRecoilX = -20f;
	public float maxRecoilY = 20f;
	//speed of recoil
	public float recoilSpeed = 5f;
	//recovery time to original position
	public float recoverSpeed = 3f;
	//kick per shot
	public float recoilAmount = 0.1f;
	//number of seconds before next bullet
	public float rateOfFire = 10f;
	//base bullet hole texture
	public GameObject bulletHoleTex;
	//recoiler controls cemra offset for recoil kick
	public GameObject Recoiller;
	//number of bullets per clip
	private int currentInClip = 30;
	//max bullets in clip
	public int clipSize = 30;
	//reload time
	public float reloadTime;
	//Bool to prevent fire when necessary
	private bool b_AllowFire = true;
	// Use this for initialization
	void Start () {
		//get hold of player stats to use for ammo
		playerGameStatControl = GameObject.Find("GameControl");

		Recoiller.GetComponent<Recoil> ().startRecoil (maxRecoilX, maxRecoilY, recoilSpeed, recoverSpeed, recoilAmount);
	}
	
	// Update is called once per frame
	void Update () {
		//set current in clip to equal weapon ammo
		currentInClip = playerGameStatControl.GetComponent<GameControl> ().Ammo;

		//coroutines are continually called but allow delays in part of the function
		//calls check weapon fire continually, but allow enumerator access
		StartCoroutine (CheckWeaponFire ());

		StartCoroutine (reloadWeapon ());
			
	}
	//A function that waits a period of time before allowing firing again using R-o-f param
	IEnumerator CheckWeaponFire(){
		//check Button, if firing is allowed, if ammo is in clip;
		if (Input.GetMouseButton (0) && b_AllowFire == true && currentInClip > 0) {
			

			//prevent  additional firing
			b_AllowFire = false;

			//call fire script
			FireWeapon ();

			//pauses the function for rateOfFire seconds before continuing
			yield return new WaitForSeconds (rateOfFire);

			//allow firing again
			b_AllowFire = true;
			Debug.Log ("firing allowed");


		}
}

	void FireWeapon(){
		
		Debug.Log ("beginning");
		// reduce ammo when firing
		playerGameStatControl.GetComponent<GameControl> ().ChangeAmmo (-1);
		// add a recoil to the recoiller
		Recoiller.GetComponent<Recoil> ().increaseRecoil ();
		Debug.Log ("end of recoil");
		//fire ray script
		GetComponentInParent<FireRay> ().RayFire (gunRange);
		Debug.Log ("function end");
		//play muzzle flash script
		GetComponent<MuzzleFlash> ().muzzleFlashPlay ();

		}

	IEnumerator reloadWeapon(){
		
		if (Input.GetKeyDown ("r")&& b_AllowFire == true && currentInClip < clipSize) {
			//reload animation here
			Debug.Log("reload start");
			b_AllowFire = false;

			yield return new WaitForSeconds (reloadTime);

			int reloadReturn = playerGameStatControl.GetComponent<GameControl> ().ChangeReserve ((clipSize -= currentInClip));
			playerGameStatControl.GetComponent<GameControl> ().ChangeAmmo ((reloadReturn));

			b_AllowFire = true;
			Debug.Log("reload end");

		}


	}
}
