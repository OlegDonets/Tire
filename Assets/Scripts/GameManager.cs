using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Objects;

public class GameManager : MonoBehaviour 
{

	public delegate void DestroyAction ();
	public static event DestroyAction OnClicked;

	public ScrollRect scrollView;
	public Text scoreText; 
	public int score;

	private XMLSaver _xml;
	private AudioSource _audioSource;
	private bool _isObj; // есть ли како-то объект на сцене

	void Start () 
	{
		_audioSource = GetComponent<AudioSource> ();
		_xml = GetComponent<XMLSaver> ();
	}

	void Update () 
	{
		if (_isObj) { //если есть объект на сцене, то "ловим" позицию клика и пускаем луч
			if (Input.GetMouseButton (0)) {
				Ray raycast = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit raycastHit;
				if (Physics.Raycast (raycast, out raycastHit)) {
					Item obj = raycastHit.collider.GetComponent<Item> ();
					if (obj) { //попали ли мы в объект 
						obj.Subscribe ();
						if (OnClicked != null) {
							_audioSource.Play ();
							OnClicked ();
							_xml.Replace ();
							_isObj = false;
						}
					}
				}
			}
		}
	}

	public void AddScore (int amount) 
	{
		score += amount;
		scoreText.text = score.ToString ();
	}

	//функция для UI Button
	public void Spawn (GameObject obj) 
	{
		if (!_isObj) {
			Instantiate (obj, Vector3.zero + Vector3.up, Quaternion.identity);
			_isObj = true;
		}
	}
}