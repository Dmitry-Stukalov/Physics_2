using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class All_Objects : MonoBehaviour
{
	private List<GameObject> First;
	private List<GameObject> Second;
	private List<GameObject> Third;

	public void Start()
	{
		First = new List<GameObject>();
		Second = new List<GameObject>();
		Third = new List<GameObject>();

		AllUnActive();
	}
	
	public void AllUnActive()
	{
		foreach (var objects in GameObject.FindGameObjectsWithTag("1"))
		{
			First.Add(objects);
			objects.SetActive(false);
		}

		foreach (var objects in GameObject.FindGameObjectsWithTag("2"))
		{
			Second.Add(objects);
			objects.SetActive(false);
		}

		foreach (var objects in GameObject.FindGameObjectsWithTag("3"))
		{
			Third.Add(objects);
			objects.SetActive(false);
		}
	}

	public void ActiveFirst()
	{
		foreach (var objects in First)
		{
			objects.SetActive(true);
		}
	}

	public void ActiveSecond()
	{
		foreach (var objects in Second)
		{
			objects.SetActive(true);
		}
	}

	public void ActiveThird()
	{
		foreach (var objects in Third)
		{
			objects.SetActive(true);
		}
	}

}
