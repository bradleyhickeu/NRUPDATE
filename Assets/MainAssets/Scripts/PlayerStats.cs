using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {
	public GameObject blood; //create public gameobject blood
	public GameObject blood2; //create public gameobject blood (faded version)
	public GameObject blood3; //create public gameobject blood (faded version)
	public float healthValue = 15; //create health variable and set it at 100
	private int distance = 1;
	public bool bloodOnScreen = false;
	public bool bloodOnScreen2 = false;
	public bool bloodOnScreen3 = false;
	private GameObject clone;
	private GameObject clone2;
	private GameObject clone3;
	//public Camera Camera;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		healthValue = healthValue + 0.01f; //health gradually increases during gameplay
		//Debug.Log (healthValue);
		if (healthValue > 99) { //if health is more than 99
			healthValue = 100; //make health 100 (done this so health doesn't surpass 100
		}
		if (healthValue <= 30  && healthValue > 20 && bloodOnScreen == false) //if health is less than 30
		{
			GameObject.Destroy (clone2);
			GameObject.Destroy (clone3);
			clone = Instantiate(blood3, transform.position + transform.forward*distance, transform.rotation)as GameObject; //add blood to scene
			clone.transform.parent = GameObject.Find("Canvas").transform;
			bloodOnScreen = true;

			//blood.transform.localPosition.x;

		}
		if (healthValue > 30 && bloodOnScreen == true)
		{
			Debug.Log("kill");
			GameObject.Destroy (clone);
			bloodOnScreen = false;
			bloodOnScreen2 = false;
			bloodOnScreen3 = false;

		}
		if (healthValue < 20 && healthValue > 10 && bloodOnScreen2 == false) {
			
			clone2 = Instantiate(blood2, transform.position + transform.forward*distance, transform.rotation)as GameObject; //add blood to scene
			clone2.transform.parent = GameObject.Find("Canvas").transform;
			GameObject.Destroy (clone);
			GameObject.Destroy (clone3);
			bloodOnScreen2 = true;
		}
		if (healthValue <= 10 && bloodOnScreen3 == false) {
			
			GameObject.Destroy (clone2);
			GameObject.Destroy (clone);
			clone3 = Instantiate(blood, transform.position + transform.forward*distance, transform.rotation)as GameObject; //add blood to scene
			clone3.transform.parent = GameObject.Find("Canvas").transform;
			bloodOnScreen3 = true;
		}
		}
	}

