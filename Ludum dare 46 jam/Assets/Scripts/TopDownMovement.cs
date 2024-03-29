﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TopDownMovement : MonoBehaviour
{

	[SerializeField]
	int Velocidade;
	Rigidbody2D RB;
	int vertical, horizontal;

	[SerializeField]
	bool IA; 

	void Start()
	{
		RB = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		if (!IA)
		{
			Mover();
		}
	}

	void Mover()
	{
		if (Input.GetKeyDown(KeyCode.A))
		{
			horizontal = -1;
		}
		else if (Input.GetKeyDown(KeyCode.D))
		{
			horizontal = 1;
		}
		else if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
		{
			horizontal = 0;
		}

		if (Input.GetKeyDown(KeyCode.W))
		{
			vertical = 1;
		}else if (Input.GetKeyDown(KeyCode.S))
		{
			vertical = -1;
		}else if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
		{
			vertical = 0;
		}
		RB.velocity = new Vector3(horizontal, vertical, 0) * Velocidade;

		if (GetComponent<Animator>())
		{
			GetComponent<Animator>().SetInteger("Move", horizontal);
		}
	}

	public bool isMoving()
	{
		return (vertical != 0 || horizontal != 0);
	}
}
