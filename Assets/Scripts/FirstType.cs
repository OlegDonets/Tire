using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Objects;

//условно первый тип
public class FirstType : Item 
{
	
	public ParticleSystem particle; //создаем партиклы после уничтожения

	public override void DestroyObj () 
	{
		Destroy (gameObject);
		ParticleSystem obj = Instantiate (particle, transform.position, Quaternion.identity);
		Destroy (obj.gameObject, 1f);
		gameManager.AddScore (reward);
		GameManager.OnClicked -= DestroyObj;
	}
}
