using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartButton : MonoBehaviour, IPointerClickHandler
{
	private TextMeshProUGUI Button { get; set; }
	private Bullet Bullet { get; set; }
	private bool IsStart { get; set; }

	public void Start()
	{
		IsStart = false;

		Button = GetComponentInChildren<TextMeshProUGUI>();
		Button.text = "�����";
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (!IsStart)
		{
			Bullet = GameObject.FindGameObjectWithTag("Bullet").GetComponent<Bullet>();
			Bullet.IsMoving = true;
			IsStart = true;

			Button.text = "�����";
		}
		else
		{
			Bullet.IsMoving = false;
			IsStart = false;

			Button.text = "����������";
		}
	}

	public void ResetData()
	{
		Button.text = "�����";
		IsStart = false;
	}
}