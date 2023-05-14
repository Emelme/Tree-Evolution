using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class Sprout : MonoBehaviour
{
	private NewUpdate nu;

	private Genome genome;
	private SproutData sd;

	public GameObject sproutGameObject;
	public GameObject cellGameObject;

	private void Start()
	{
		nu = FindObjectOfType<NewUpdate>();

		genome = GetComponentInParent<Genome>();
		sd = GetComponent<SproutData>();
	}

	private void NewUpdate()
	{

	}

	private void Update()
	{
		if (nu.canDo)
		{
			NewUpdate();
		}
	}
}