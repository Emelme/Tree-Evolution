using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class Genome : MonoBehaviour
{
	public Gene[] genome = new Gene[16];

	private void Start()
	{
		for (int i = 0; i < genome.Length; i++)
		{
			genome[i] = new Gene();
		}
	}

	public void RandomValueInGene()
	{
		for (int i = 0; i < genome.Length; i++)
		{
			genome[i].number = ++i;

			if (Random.Range(0, 3) == 0) genome[i].leftGene = Random.Range(1, 17);
			if (Random.Range(0, 3) == 0) genome[i].leftUpGene = Random.Range(1, 17);
			if (Random.Range(0, 3) == 0) genome[i].rightUpGene = Random.Range(1, 17);
			if (Random.Range(0, 3) == 0) genome[i].rightGene = Random.Range(1, 17);
			if (Random.Range(0, 3) == 0) genome[i].rightDownGene = Random.Range(1, 17);
			if (Random.Range(0, 3) == 0) genome[i].leftDownGene = Random.Range(1, 17);

			genome[i].parameter1 =

			if (Random.Range(0, 4) == 0)
			{
			}
		}
	}
}
