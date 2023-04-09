using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprout : MonoBehaviour
{
	public Genome genome;

	private void Start()
	{
		genome = GetComponentInParent<Genome>();
	}
}