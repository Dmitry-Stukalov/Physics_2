using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	private GameObject Center { get; set; }
	private Vector3 targetDirection { get; set; }
	private float rotationSpeed { get; set; } = 50;

	public float pi { get; set; } = 3.14f;
	public float X { get; set; }
	public float Y { get; set; }
	public float Z { get; set; }
	public float T { get; set; }									//Период в
	public float A { get; set; }
	public float S { get; set; }
	public float R { get; set; }
	public float V { get; set; }
	public float u { get; set; }									//Частота вращения
	public float v { get; set; }									//Линейная скорость
	public float W { get; set; }									//Угловая скорость
	public float N { get; set; }
	public float Angle { get; set; }
	public bool IsMoving { get; set; }

	public event Action OnResetData;


	public void Start()
	{
		Center = GameObject.FindGameObjectWithTag("Center");
		targetDirection = transform.position.normalized;
		ResetData();
	}

	public void ResetData()
	{
		X = 2;
		Y = 0;
		Z = 0;
		T = 0;
		A = 0;
		S = 0;
		R = 0;
		V = 0;
		u = 2;
		W = 0;
		N = 0;
		Angle = 0;

		transform.position = new Vector3(X, Y, Z);
		transform.rotation = Quaternion.Euler(-90, 0, 0);

		IsMoving = false;

		OnResetData?.Invoke();
	}

	public void ChangeVariableValue(string axis, float value)
	{
		switch (axis)
		{
			case "u":
				u = value;
				W = 2 * pi * u;
				break;

			case "R":
				R = value;
				X = Center.transform.position.x + R;
				transform.position = new Vector3(X, Y, Z);
				break;
		}

	}

	public float GetVariableValue(string axis)
	{
		switch (axis)
		{
			case "T":
				return T;

			case "A":
				return A%360;

			case "W":
				return W;

			case "S":
				return S;

			case "Angle":
				return Angle;

			case "X":
				return X;

			case "Y":
				return Y;

			case "Z":
				return Z;

			case "N":
				return N;

			case "v":
				return v;
		}

		return 0;
	}

	public void FixedUpdate()
	{
		if (IsMoving)
		{
			T += Time.deltaTime;

			N = T * u;

			v = 2 * pi * R * u;

			Angle += W * Time.deltaTime;

			A = Angle * Mathf.Rad2Deg;

			S = 2 * pi * R / 360 * A;

			X = Center.transform.position.x + R * Mathf.Cos(Angle);
			Z = Center.transform.position.z + R * Mathf.Sin(Angle);

			targetDirection = new Vector3(X, Y, Z);

			if (targetDirection != Vector3.zero)
			{
				Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up) * Quaternion.Euler(0, -90, 0);
				transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Convert.ToSingle(rotationSpeed * Time.deltaTime));
			}

			gameObject.transform.position = new Vector3(X, Y, Z);
		}
	}
}