using UnityEngine;
using System.Collections;

public class Jin : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//set degreeToTarget for Jin
		GetComponent<Animator>().SetInteger ("degreeToTarget",transform.GetComponentInParent<Hero> ().degreeToTarget);
	}

	public void spawnFireBall()
	{
		//spawn fire normal attack projectile
		transform.GetComponentInParent<HeroAttack> ().spawnProjectile ();
	}
}
