using UnityEngine;
using System.Collections;

public class RedJinDamage : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Enemy")
		{
			//the enemy will burned for 6 seconds and took damage every 2 seconds
			other.GetComponent<Enemy>().AttackedV4(6,2);
		}	
	}
}
