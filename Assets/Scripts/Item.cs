using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Objects 
{

	public abstract class Item: MonoBehaviour 
	{

		public int reward;
		[HideInInspector]public GameManager gameManager;

		private void Start () 
		{
			gameManager = FindObjectOfType<GameManager> ();
		}

		public void Subscribe() 
		{
			GameManager.OnClicked += DestroyObj;
		}

		public abstract void DestroyObj();
	}
}
