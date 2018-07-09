using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class XMLSaver : MonoBehaviour 
{

	[SerializeField]
	private GameManager _gameManager;

	void Start () 
	{
		_gameManager = GetComponent<GameManager> ();
		Load ();
	}

	public void Save () 
	{
		XmlDocument xmlDoc = new XmlDocument ();
		XmlNode rootNode = xmlDoc.CreateElement("Info");
		xmlDoc.AppendChild (rootNode);

		XmlNode userNode;

		userNode = xmlDoc.CreateElement ("Score");
		userNode.InnerText = _gameManager.score.ToString();
		rootNode.AppendChild (userNode);

		xmlDoc.Save ("Data/Save.xml");
	}

	public void Replace () 
	{
		XmlDocument xmlDoc = new XmlDocument ();
		xmlDoc.Load ("Data/Save.xml");
		xmlDoc.SelectSingleNode("Info/Score").InnerText = _gameManager.score.ToString();
		xmlDoc.Save ("Data/Save.xml");
	}

	private void Load () 
	{
		XmlTextReader reader = new XmlTextReader ("Data/Save.xml");
		while (reader.Read()) {
			if (reader.IsStartElement("Score") && !reader.IsEmptyElement) {
				_gameManager.AddScore(int.Parse(reader.ReadString ()));
			}
		}
		reader.Close ();
	}
}
