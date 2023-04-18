using System.Collections.Generic;
using UnityEngine;

public class Genome : MonoBehaviour
{
	public Gene[] genes = new Gene[16];

	private void Start()
	{
		foreach (Gene gene in genes)
		{
			gene.GenerateAlmostRandomNextGrowthGenes(75, 50, 25);
		}
	}
}