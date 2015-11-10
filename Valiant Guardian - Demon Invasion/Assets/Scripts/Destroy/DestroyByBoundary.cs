using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour
{
    //double filter to make sure everything is clean outside the boundary

    void OnTriggerEnter2D(Collider2D other)
    {
		if (other.tag == "SkillProjectile") {

		} 
		else {
			Destroy(other.gameObject);
		}
    }

    void OnTriggerExit2D(Collider2D other)
    {
		if (other.tag == "SkillProjectile") {
			
		} 
		else {
			Destroy(other.gameObject);
		}
    }
}