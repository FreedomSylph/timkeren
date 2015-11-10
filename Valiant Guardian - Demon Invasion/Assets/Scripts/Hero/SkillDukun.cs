using UnityEngine;
using System.Collections;

public class SkillDukun : MonoBehaviour
{

    public GameObject normProjectiles;
    public GameObject ultiProjectiles;
	
	public GameObject Jin;

	public GameObject spawnedProjectile;
    private Hero hero;

    void Awake()
    {
        hero = GetComponent<Hero>();
    }

	void Update()
	{
		Jin.transform.rotation = Quaternion.identity;
	}

    public void normalSkill()
    {
		//StartCoroutine(bulletBurst());  
		hero.aimAtEnemy();
		spawnNormProjectile();
    }

    IEnumerator bulletBurst()
    {
        for (int i = 0; i < 3; i++)
        {
            //make sure the projectile aiming at enemy
            hero.aimAtEnemy();
            spawnNormProjectile();
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void ultimateSkill()
    {
        //make sure the projectile aiming at enemy
        hero.aimAtEnemy();
        spawnUltiProjectile();
    }

	/// <summary>
	/// Spawns the fire projectile for the jin to do normal attack.
	/// </summary>
	public void spawnFireProjectile()
	{
		Jin.GetComponent<Animator>().SetTrigger("isAttacking");
		//GetComponent<HeroAttack> ().spawnProjectile ();
	}

	public void jinTransform()
	{
		Jin.GetComponent<Animator> ().Play ("Jin-Transform-Anim");
		//GetComponent<HeroAttack> ().spawnProjectile ();
	}

    public void spawnUltiProjectile()
    {
        //spawning projectile for ultimate skill
        //called from animation
		GameObject projectile =(GameObject)Instantiate(ultiProjectiles, new Vector3(0,0,10), Quaternion.identity);
		
		projectile.transform.parent = this.transform;
		projectile.transform.position = new Vector3 (0, 0, 10);
		spawnedProjectile = projectile;
		gameObject.GetComponentInParent<HeroSkillTrigger> ().PauseHeroAnimation ();
	}
	
	public void spawnNormProjectile()
    {
        //spawning projectile
        //called from animation
		GameObject projectile =(GameObject)Instantiate(normProjectiles, new Vector3(0,0,10), Quaternion.identity);
	
		projectile.transform.parent = this.transform;
		projectile.transform.position = new Vector3 (0, 0, 10);
		gameObject.GetComponentInParent<HeroSkillTrigger> ().PauseHeroAnimation ();
    }
}