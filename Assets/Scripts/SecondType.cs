using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Objects;

//условно второй тип
public class SecondType : Item 
{
	
	public GameObject spawnObj; //обЪект, который создаем после уничтожения

	public override void DestroyObj () 
	{
		GameObject obj = Instantiate (spawnObj, transform.position, spawnObj.transform.rotation);
		Destroy (obj, 0.5f);
		gameManager.AddScore (reward);
		GameManager.OnClicked -= DestroyObj;
		Destroy (gameObject);
	}
}
