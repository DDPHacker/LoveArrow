using UnityEngine;

//This script handles any items that leave the scene
public class DestroyArea : MonoBehaviour
{
	void OnTriggerExit2D (Collider2D c)
	{
		//Get the items layer name
		string layerName = LayerMask.LayerToName (c.gameObject.layer);

		//If it is an enemy...
		if (layerName == "Enemy")
			//...deactivate it (since enemies aren't a part of the generic pool)...
			c.gameObject.SetActive (false);
		//...otherwise...
		else
			//...send it to the pool.
			ObjectPool.current.PoolObject(c.gameObject);
	}
}