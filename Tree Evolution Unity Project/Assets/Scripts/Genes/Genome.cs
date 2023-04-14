using System.Collections.Generic;
using UnityEngine;

public class Genome : MonoBehaviour
{
	public Gene[] genes = new Gene[16];

	private TreeData treeData;
	private SproutData sproutData;

	private Dictionary<Gene.Parameters, int> parameterDictionary;

	private Gene.Parameters parameter1;
	private Gene.Parameters parameter2;
	private Gene.Parameters parameter3;
	private Gene.Parameters parameter4;

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

		RandomValueInGenes(growthChanceUp, growthChanceSide, growthChanceDown, numberChanceParameter1, numberChanceParameter2, numberChanceParameter3, numberChanceParameter4);
	}

	private void Update()
	{
		//for (int i = 0; i < genes.Length; i++)
		//{
		//	if (genes[i].hasCondition1)
		//	{
		//		if (parameter1 != Gene.Parameters.number)
		//		{
		//			parameterDictionary.TryGetValue(parameter1, out genes[i].parameter1);
		//		}
		//		if (parameter2 != Gene.Parameters.number)
		//		{
		//			parameterDictionary.TryGetValue(parameter2, out genes[i].parameter2);
		//		}
		//	}
		//	else if (genes[i].hasCondition2)
		//	{
		//		if (parameter3 != Gene.Parameters.number)
		//		{
		//			parameterDictionary.TryGetValue(parameter3, out genes[i].parameter3);
		//		}
		//		if (parameter4 != Gene.Parameters.number)
		//		{
		//			parameterDictionary.TryGetValue(parameter4, out genes[i].parameter4);
		//		}
		//	}
		//}
	}

	public void RandomValueInGenes(int growthChanceUp, int growthChanceSide, int growthChanceDown, int numberChanceParameter1, int numberChanceParameter2, int numberChanceParameter3, int numberChanceParameter4)
	{
		for (int i = 0; i < genes.Length; i++)
		{
			if (Random.Range(1, 101) <= growthChanceSide) genes[i].LeftGene = Random.Range(0, 16);
			if (Random.Range(1, 101) <= growthChanceUp) genes[i].LeftUpGene = Random.Range(0, 16);
			if (Random.Range(1, 101) <= growthChanceUp) genes[i].RightUpGene = Random.Range(0, 16);
			if (Random.Range(1, 101) <= growthChanceSide) genes[i].RightGene = Random.Range(0, 16);
			if (Random.Range(1, 101) <= growthChanceDown) genes[i].RightDownGene = Random.Range(0, 16);
			if (Random.Range(1, 101) <= growthChanceDown) genes[i].LeftDownGene = Random.Range(0, 16);

			genes[i].HasCondition1 = Random.Range(0, 2) == 0;
			genes[i].HasCondition2 = Random.Range(0, 2) == 0;
			
			if (genes[i].HasCondition1)
			{
				if (Random.Range(1, 101) <= numberChanceParameter1)
				{
					genes[i].Parameter1 = Random.Range(0, 64);
					parameter1 = Gene.Parameters.number;
					parameter2 = (Gene.Parameters)Random.Range(0, 16);
					parameterDictionary.TryGetValue(parameter2, out genes[i].parameter2);
				}
				else
				{
					parameter1 = (Gene.Parameters)Random.Range(0, 16);
					parameterDictionary.TryGetValue(parameter1, out genes[i].parameter1);

					if (Random.Range(1, 101) <= numberChanceParameter2)
					{
						genes[i].Parameter2 = Random.Range(0, 64);
						parameter2 = Gene.Parameters.number;
					}
					else
					{
						parameter2 = (Gene.Parameters)Random.Range(0, 16);
						parameterDictionary.TryGetValue(parameter2, out genes[i].parameter2);
					}
				}
			}

			if (genes[i].HasCondition1 && genes[i].HasCondition2)
			{
				if (Random.Range(1, 101) >= numberChanceParameter3)
				{
					genes[i].Parameter3 = Random.Range(0, 64);
					parameter3 = Gene.Parameters.number;
					parameter4 = (Gene.Parameters)Random.Range(0, 16);
					parameterDictionary.TryGetValue(parameter4, out genes[i].parameter4);
				}
				else
				{
					parameter3 = (Gene.Parameters)Random.Range(0, 16);
					parameterDictionary.TryGetValue(parameter3, out genes[i].parameter3);

					if (Random.Range(1, 101) <= numberChanceParameter4)
					{
						genes[i].Parameter4 = Random.Range(0, 64);
						parameter4 = Gene.Parameters.number;
					}
					else
					{
						parameter4 = (Gene.Parameters)Random.Range(0, 16);
						parameterDictionary.TryGetValue(parameter4, out genes[i].parameter4);
					}
				}
			}

			if (genes[i].HasCondition1)
			{
				genes[i].Operator1 = (Gene.Operators)Random.Range(0, 6);

				if (genes[i].HasCondition2)
				{
					genes[i].Operator2 = (Gene.Operators)Random.Range(0, 6);
				}
			}

			if (genes[i].HasCondition1 && genes[i].HasCondition2)
			{
				genes[i].BooleanOperator = (Gene.BooleanOperators)Random.Range(0, 3);
			}

			if (genes[i].HasCondition1)
			{
				genes[i].IfTrue = (Gene.IfTrueDo)Random.Range(0, 4);

				if (genes[i].IfTrue == Gene.IfTrueDo.changeGeneTo)
				{
					genes[i].NextGeneIfTrue = Random.Range(0, 16);
				}
			}
		}
	}
}