using UnityEngine;
using System.Collections;

//This script controls the enemy ships
public class Enemy : Spaceship
{
	public int hp = 1;			//Ship's hit points
	public int point = 100;		//Ship's point worth 

	int currentHP;				//Ship's current hit points


	//Override parent's OnEnable method
	protected override void OnEnable ()
	{
		//Call parent's OnEnable method
		base.OnEnable ();
		//Initialize the ship's hit points and speed
		currentHP = hp;
		GetComponent<Rigidbody2D>().velocity = (transform.up * -1) * speed;
	}

	void OnTriggerEnter2D (Collider2D c)
	{
		//Get item's layer name
		string layerName = LayerMask.LayerToName (c.gameObject.layer);
		//If the ship did not collide with a player's bullet, ignore it
		if (layerName != "Bullet (Player)") 
			return;

		//Get the bullet's Bullet script
		Bullet obj = c.GetComponent<Bullet>();
		//Subtract bullet's damage from hit points
		currentHP -= obj.power;
		//Return bullet to the pool
		ObjectPool.current.PoolObject(c.gameObject);
		//If the ship is out of hit points...
		if(currentHP <= 0 )
		{
			//...add to the player's score...
			Manager.current.AddPoint(point);
			//...call the parent Explode method...
			Explode ();
			//...and deactivate this ship.
			gameObject.SetActive(false);

		}else{
			//Otherwise, play the damaged animation
			animator.SetTrigger("Damage");
		
		}
	}
}