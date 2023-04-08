using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class Genome : MonoBehaviour
{
	public Gene[] genome = new Gene[16];

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

		parameterDictionary = new Dictionary<Gene.Parameters, int>
		{
			{ Gene.Parameters.maxAge, treeData.maxAge },
			{ Gene.Parameters.age, treeData.age },
			{ Gene.Parameters.mass, treeData.mass },
			{ Gene.Parameters.cellAmount, treeData.cellAmount },
			{ Gene.Parameters.sproutAmount, treeData.sproutAmount },
			{ Gene.Parameters.height, treeData.height },
			{ Gene.Parameters.width, treeData.width },
			{ Gene.Parameters.startEnergy, treeData.startEnergy },
			{ Gene.Parameters.energyPerCell, treeData.energyPerCell },
			{ Gene.Parameters.needEnergyWholeTree, treeData.needEnergyWholeTree },
			{ Gene.Parameters.energyOfSunGetsTree, treeData.energyOfSunGetsTree },
			{ Gene.Parameters.heightOfSprout, sproutData.heightOfSprout },
			{ Gene.Parameters.energyOfSprout, sproutData.energyOfSprout },
			{ Gene.Parameters.energyOfSunGetsSprout, sproutData.energyOfSunGetsSprout }
		};

		for (int i = 0; i < genome.Length; i++)
		{
			genome[i] = new Gene();
		}

		RandomValueInGenes(growthChanceUp, growthChanceSide, growthChanceDown, numberChanceParameter1, numberChanceParameter2, numberChanceParameter3, numberChanceParameter4);
	}

	private void Update()
	{
		for (int i = 0; i < genome.Length; i++)
		{
			if (genome[i].hasCondition1)
			{
				if (parameter1 != Gene.Parameters.number)
				{
					parameterDictionary.TryGetValue(parameter1, out genome[i].parameter1);
				}
				if (parameter2 != Gene.Parameters.number)
				{
					parameterDictionary.TryGetValue(parameter2, out genome[i].parameter2);
				}
			}
			else if (genome[i].hasCondition2)
			{
				if (parameter3 != Gene.Parameters.number)
				{
					parameterDictionary.TryGetValue(parameter3, out genome[i].parameter3);
				}
				if (parameter4 != Gene.Parameters.number)
				{
					parameterDictionary.TryGetValue(parameter4, out genome[i].parameter4);
				}
			}
		}
	}

	public void RandomValueInGenes(int growthChanceUp, int growthChanceSide, int growthChanceDown, int numberChanceParameter1, int numberChanceParameter2, int numberChanceParameter3, int numberChanceParameter4)
	{
		for (int i = 0; i < genome.Length; i++)
		{
			genome[i].number = i + 1;

			if (Random.Range(1, 101) <= growthChanceSide) genome[i].leftGene = Random.Range(1, 17);
			Debug.Log($"{genome[i].number}, {genome[i].leftGene}");
			if (Random.Range(1, 101) <= growthChanceUp) genome[i].leftUpGene = Random.Range(1, 17);
			Debug.Log($"{genome[i].number}, {genome[i].leftUpGene}");
			if (Random.Range(1, 101) <= growthChanceUp) genome[i].rightUpGene = Random.Range(1, 17);
			Debug.Log($"{genome[i].number}, {genome[i].rightUpGene}");
			if (Random.Range(1, 101) <= growthChanceSide) genome[i].rightGene = Random.Range(1, 17);
			Debug.Log($"{genome[i].number}, {genome[i].rightGene}");
			if (Random.Range(1, 101) <= growthChanceDown) genome[i].rightDownGene = Random.Range(1, 17);
			Debug.Log($"{genome[i].number}, {genome[i].rightDownGene}");
			if (Random.Range(1, 101) <= growthChanceDown) genome[i].leftDownGene = Random.Range(1, 17);
			Debug.Log($"{genome[i].number}, {genome[i].leftDownGene}");

			genome[i].hasCondition1 = Random.Range(0, 2) == 0;
			genome[i].hasCondition2 = Random.Range(0, 2) == 0;
			
			if (genome[i].hasCondition1)
			{
				if (Random.Range(1, 101) <= numberChanceParameter1)
				{
					genome[i].parameter1 = Random.Range(0, 64);
					parameter1 = Gene.Parameters.number;
					parameter2 = (Gene.Parameters)Random.Range(0, 16);
					parameterDictionary.TryGetValue(parameter2, out genome[i].parameter2);
				}
				else
				{
					parameter1 = (Gene.Parameters)Random.Range(0, 16);
					parameterDictionary.TryGetValue(parameter1, out genome[i].parameter1);

					if (Random.Range(1, 101) <= numberChanceParameter2)
					{
						genome[i].parameter2 = Random.Range(0, 64);
						parameter2 = Gene.Parameters.number;
					}
					else
					{
						parameter2 = (Gene.Parameters)Random.Range(0, 16);
						parameterDictionary.TryGetValue(parameter2, out genome[i].parameter2);
					}
				}
			}

			if (genome[i].hasCondition1 && genome[i].hasCondition2)
			{
				if (Random.Range(1, 101) >= numberChanceParameter3)
				{
					genome[i].parameter3 = Random.Range(0, 64);
					parameter3 = Gene.Parameters.number;
					parameter4 = (Gene.Parameters)Random.Range(0, 16);
					parameterDictionary.TryGetValue(parameter4, out genome[i].parameter4);
				}
				else
				{
					parameter3 = (Gene.Parameters)Random.Range(0, 16);
					parameterDictionary.TryGetValue(parameter3, out genome[i].parameter3);

					if (Random.Range(1, 101) <= numberChanceParameter4)
					{
						genome[i].parameter4 = Random.Range(0, 64);
						parameter4 = Gene.Parameters.number;
					}
					else
					{
						parameter4 = (Gene.Parameters)Random.Range(0, 16);
						parameterDictionary.TryGetValue(parameter4, out genome[i].parameter4);
					}
				}
			}

			if (genome[i].hasCondition1)
			{
				genome[i].operator1 = (Gene.Operators)Random.Range(0, 6);

				if (genome[i].hasCondition2)
				{
					genome[i].operator2 = (Gene.Operators)Random.Range(0, 6);
				}
			}

			if (genome[i].hasCondition1 && genome[i].hasCondition2)
			{
				genome[i].booleanOperator = (Gene.BooleanOperators)Random.Range(0, 3);
			}

			if (genome[i].hasCondition1)
			{
				genome[i].nextGeneIfTrue = Random.Range(1, 17);
			}
		}
	}
}