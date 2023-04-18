using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class Sprout : MonoBehaviour
{
	private Genome genome;
	private SproutData sd;

	public GameObject sproutGameObject;
	public GameObject cellGameObject;

	private float timer;

	private void Start()
	{
		genome = GetComponentInParent<Genome>();
		sd = GetComponent<SproutData>();
	}

	private void NewUpdate()
	{

	}

	private void Update()
	{
		//timer += Time.deltaTime;

		//if (timer > 1f)
		//{
		//	NewUpdate();
		//	timer = 0f;
		//}

		if (Input.GetMouseButtonDown(0))
		{
			NewUpdate();
		}
	}
}