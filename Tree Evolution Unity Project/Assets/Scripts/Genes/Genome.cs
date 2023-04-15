using System.Collections.Generic;
using UnityEngine;

public class Genome : MonoBehaviour
{
	public Gene[] genes = new Gene[16];

	private TreeData treeData;
	private SproutData sproutData;

	private Dictionary<Gene.Parameters, int> parameterDictionary;

	public int growthChanceUp;
	public int growthChanceSide;
	public int growthChanceDown;
	[Space(20)]
	public int numberChanceParameter1;
	public int numberChanceParameter2;
	public int numberChanceParameter3;
	public int numberChanceParameter4;

	private void Start()
	{
		treeData = GetComponentInParent<TreeData>();
		sproutData = GetComponentInChildren<SproutData>();

		for (int i = 0; i < genes.Length; i++)
		{
			genes[i] = new Gene();
		}
	}
}