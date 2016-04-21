using UnityEngine;
using System.Collections;

public class MuzzleFlash : MonoBehaviour {
	public ParticleSystem flashParticle;
	public Light muzzleFlashLight;

	// Use this for initialization
	void Start () {
		muzzleFlashLight.enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
	{

	}
	public void muzzleFlashPlay(){
		flashParticle.Play ();
		flashParticle.Emit (15);
		muzzleFlashLight.enabled = true;
		//yield WaitForSeconds(3);
		//yield return new WaitForSeconds(1);
		//flashParticle.Stop ();
		Invoke("muzzleFlashStop",0.1f);

	}
	public void muzzleFlashStop(){
		muzzleFlashLight.enabled = false;
	
	}
	}

