using UnityEngine;
using System.Collections;

public class OrbitalHack : MonoBehaviour {
	
	SpriteRenderer spriteRenderer;
	
	public GameObject target;
	public GameObject chickenProjectile;
	HeroSkillTrigger heroSkillTrigger;
	
	public int enemyHitLimit = 4;
	private int countEnemiesTargeted;
	private string[] enemiesRealName;
	public GameObject[] enemiesCaught;
	private string markedTargetName;    //All targeted enemies marked by this name
	private int countEnemiesHit;
	
	public Vector3 ground;
	bool groundClicked;
	bool reachGround;
	public int spawnNum;
	public float explosionRadius;
	
	public float radius;
	public float speed;
	
	private bool isFindingTarget = false;
	private bool projectileVisible = false;
	
	public GameObject soundHitGO;
	public AudioClip soundHit;
	
	public GameObject[] enemiesOnRadius;
	
	Enemy[] enemyInstance; 
	
	
	public float slowandpoisonDelay;
	public int poison;
	Vector3 temp2;
	
	void Start()
	{
		//set the chicken movement
		//To mark the arrow not visible before launch
		//spriteRenderer = GetComponent<SpriteRenderer>();
		//spriteRenderer.enabled = false;
		groundClicked = false;
		reachGround = false;
		enemiesRealName = new string[enemyHitLimit];
		enemiesCaught = new GameObject[enemyHitLimit];	
		heroSkillTrigger = transform.parent.GetComponent<HeroSkillTrigger>();
		countEnemiesTargeted = 0;
		countEnemiesHit = 0;
		markedTargetName = "OrbitalHackVictim";

	

	}

	public void explode()
	{
		// check enemy in circle area
		Collider2D[] col = Physics2D.OverlapCircleAll (transform.position, GetComponent<CircleCollider2D> ().radius);
		for(int i =0 ;i<col.Length;i++)
		{
			if(!col[i].GetComponent<Enemy>())
			{ 
				continue;
				//return;
			}
			//damage * 3
			col[i].GetComponent<Enemy>().AttackedV5();
		}
	}
	void Update()
	{
		
		
		if (Input.GetButtonDown("Fire1") && !isFindingTarget)
			setFirstEnemyOnTap();
		
		//Set the object rotation
		if (groundClicked)
		{
			//Quaternion direction = Quaternion.LookRotation(ground - this.transform.position, this.transform.TransformDirection(Vector3.up));
			//this.transform.rotation = new Quaternion(0, 0, direction.z, direction.w);
		}
		
		
	}
	
	void setFirstEnemyOnTap()
	{
		if (!heroSkillTrigger.canResume()) {
			return;
		}
		
		//validate the place of the jin 
		//so that it can't be too high and too close to the door
		ground = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		if (ground.x < -2.8f || ground.y >-0.9f) {
			return;
		}
		
		//GetComponent<Animator>().Play("OrbitalHack-Laser");
		groundClicked = true;
		//TargetAnEnemy(hitObject.collider);
		isFindingTarget = true;		
		//To re enable the sprite renderer when the projectile launched
		//spriteRenderer.enabled = true;		
		//To continue the attacking animation
		heroSkillTrigger.ResumeHeroAnimation();


		//place the instantiate of RedJinProjectileHolder
		//play the animation red jin and do repetition
		/*Animator[] tempAnimator =GetComponentsInChildren<Animator>();
		for(int i =0 ;i<tempAnimator.Length;i++)
		{
			tempAnimator[i].Play("Jin_Active");
		}*/
		//To play the sfx
		//GetComponent<AudioSource>().Play();
		
		
		//GameObject temp = Instantiate(gassProjectile,new Vector3(center.x,center.y,0), Quaternion.identity) as GameObject;
		
		
		/*
		RaycastHit2D hitObject = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
		if (hitObject.transform.tag == "Enemy" && Vector2.Distance(transform.position, hitObject.transform.position) <= radius)
		{
			TargetAnEnemy(hitObject.collider);
			isFindingTarget = true;
			
			//To re enable the sprite renderer when the projectile launched
			spriteRenderer.enabled = true;
			
			//To continue the attacking animation
			heroSkillTrigger.ResumeHeroAnimation();
			
			//To play the sfx
			GetComponent<AudioSource>().Play();
		}
		else
		{
			//To hide the skills button after clicking
			//heroSkillTrigger.HideSkillsHolder();
			heroSkillTrigger.ResumeHeroAnimation();
			heroSkillTrigger.RestartHeroAnimation();
			Destroy(gameObject);
		}
		*/
		//play dukun tapping 
		heroSkillTrigger.getAnimator ().Play ("Dukun_Tapping2");
		//place the instantiate of Orbital Hack
		this.transform.position = new Vector3(ground.x,ground.y,10);

	}
	/// <summary>
	/// Destroy gameobject
	/// </summary>
	public void des()
	{
		Destroy (gameObject);
	}
	
	
	void OnTriggerEnter2D(Collider2D other)
	{
		
	}
	
	
	private void disableProjectileVisulization()
	{
		//disabling projectile existence to maintain hit sound
		//while the proectile didn't affect anything in game world
		Destroy(GetComponent<Rigidbody2D>());
		Destroy(GetComponent<BoxCollider2D>());
		Destroy(GetComponent<SpriteRenderer>());
	}
	
	void TargetAnEnemy(Collider2D targetCollider)
	{
		//save the reference of the enemies in order
		enemiesCaught[countEnemiesTargeted] = targetCollider.gameObject;
		
		//save the name to be refund when the skills finished
		enemiesRealName[countEnemiesTargeted] = targetCollider.gameObject.name;
		targetCollider.gameObject.name = markedTargetName;
		
		//set the reference to current targeted enemy
		this.target = enemiesCaught[countEnemiesTargeted];
		
		countEnemiesTargeted++;
		countEnemiesHit++;
	}
	
	void TargetPreviousEnemy()
	{
		int tmpRandomTarget = Random.Range(0, countEnemiesTargeted);
		countEnemiesHit++;
	}
	
	//clasify off all enemies in the field to target in range of projectile
	void FindTargetOnRadius()
	{
		GameObject[] enemiesFound = GameObject.FindGameObjectsWithTag("Enemy");
		enemiesOnRadius = new GameObject[enemiesFound.Length];
		int enemiesOnRadiusCount = 0;
		
		for (int i = 0; i < enemiesFound.Length; i++)
		{
			if (enemiesFound[i].name != markedTargetName)
			{
				if (Vector2.Distance(transform.position, enemiesFound[i].transform.position) <= radius)
					enemiesOnRadius[enemiesOnRadiusCount++] = enemiesFound[i].gameObject;
			}
		}
		if (enemiesOnRadiusCount == 0)
		{
			TargetPreviousEnemy();
		}
		else
		{
			FindNearestTarget();
		}
	}
	
	//find the nearest target after clasified by FindTargetOnRadius() method
	void FindNearestTarget()
	{
		//temp variabel to be replace by nearest enemy found through looping
		GameObject tempNearestTarget = gameObject;
		
		//to make sure event the fartest enemy in radius got a chance
		float tempDistance = radius + 0.1f;
		
		for (int i = 0; i < enemiesOnRadius.Length; i++)
		{
			if (enemiesOnRadius[i] == null)     //because array is longer than it should
				continue;
			else
			{
				float newDistance = Vector2.Distance(transform.position, enemiesOnRadius[i].transform.position);
				//if the distance to the enemy closer than the previous distance then save it
				if (newDistance < tempDistance)
				{
					tempNearestTarget = enemiesOnRadius[i].gameObject;
					tempDistance = newDistance;
				}
			}
		}
		TargetAnEnemy(tempNearestTarget.GetComponent<Collider2D>());
	}
	
	void RefundEnemiesName()
	{
		//return the name
		for (int i = 0; i < enemiesCaught.Length; i++)
		{
			if (enemiesCaught[i] == null)
				continue;
			else
				enemiesCaught[i].name = enemiesRealName[i];
		}
	}
	
	
}
