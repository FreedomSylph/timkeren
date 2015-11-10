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

	/// <summary>
	//spawn fire normal attack projectile.
	/// </summary>
	public void spawnFireBall()
	{
		transform.GetComponentInParent<HeroAttack> ().spawnProjectile ();
	}

	/// <summary>
	/// Moves the jin for Orbital Hack Repair Animation.
	/// </summary>
	public void moveJin()
	{
		transform.position = new Vector3 (-0.84f, 1.75f, 10);
	}
	/// <summary>
	/// Backs the jin to the original position.
	/// </summary>
	public void backJin()
	{
		transform.localPosition = new Vector3 (0.4f, 0, 0);
		transform.parent.GetComponentInParent<SkillDukun> ().spawnedProjectile.GetComponent<Animator> ().Play ("OrbitalHack-Laser");
	}
}
