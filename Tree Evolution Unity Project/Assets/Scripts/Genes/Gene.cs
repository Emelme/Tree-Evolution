using UnityEngine;

public class Gene
{
	#region Data
	#region Properties
	public int Number { get; set; }

	public int LeftGene { get; set; }
	public int LeftUpGene { get; set; }
	public int RightUpGene { get; set; }
	public int RightGene { get; set; }
	public int RightDownGene { get; set; }
	public int LeftDownGene { get; set; }

	public bool HasCondition1 { get; set; }
	public Parameters Parameter1 { get; set; }
	public Operators Operator1 { get; set; }
	public Parameters Parameter2 { get; set; }
	public int RandomNumber1 { get; set; }
	public bool HasCondition2 { get; set; }
	public BooleanOperators BooleanOperator { get; set; }
	public Parameters Parameter3 { get; set; }
	public Operators Operator2 { get; set; }
	public Parameters Parameter4 { get; set; }
	public int RandomNumber2 { get; set; }
	public Actions IfTrue { get; set; }
	public int NextGeneIfTrue { get; set; }
	#endregion

	#region Enums
	public enum Parameters
	{
		number,
		maxAge,
		age,
		mass,
		cellAmount,
		sproutAmount,
		height,
		width,
		startEnergy,
		energyOfTree,
		energyOfSunGetsTree,
		energyPerCell,
		needEnergyWholeTree,
		energyOfSunGetsCell,
		heightOfSprout,
		energyOfSprout,
		energyOfSunGetsSprout
	}

	public enum Operators
	{
		equal,
		notEqual,
		lessThen,
		notLessThen,
		greaterThan,
		notGreaterThan
	}

	public enum BooleanOperators
	{
		and,
		or,
		xor
	}

	public enum Actions
	{
		changeActivGeneTo,
		fall,
		maxAgePlusOne,
		eat
	}
	#endregion
	#endregion

	#region Methods
	#region Generate Methods
	public void GenerateFullyRandomValues()
	{
		GenerateFullyRandomNextGrowthGenes();
		HasCondition1 = (Random.value < 0.5f);
		GenerateFullyRandomCondition1();
		HasCondition2 = (Random.value < 0.5f);
		GenerateFullyRandomCondition2();
		GenerateRandomIfTrueAction();
	}

	public void GenerateAlmostRandomValues(float growthChanceUp, float growthChanceSide, float growthChanceDown, float HasCondition1Chance, float numberChanceParameter1, float numberChanceParameter2, float HasCondition2Chance, float numberChanceParameter3, float numberChanceParameter4)
	{
		GenerateAlmostRandomNextGrowthGenes(growthChanceUp, growthChanceSide, growthChanceDown);
		HasCondition1 = (Random.value < HasCondition1Chance);
		GenerateAlmostRandomCondition1(numberChanceParameter1, numberChanceParameter2);
		HasCondition1 = (Random.value < HasCondition2Chance);
		GenerateAlmostRandomCondition2(numberChanceParameter3, numberChanceParameter4);
		GenerateRandomIfTrueAction();
	}

	public void GenerateFullyRandomNextGrowthGenes()
	{
		if (Random.value < 0.5f) LeftGene = Random.Range(1, 17);
		if (Random.value < 0.5f) LeftUpGene = Random.Range(1, 17);
		if (Random.value < 0.5f) RightUpGene = Random.Range(1, 17);
		if (Random.value < 0.5f) RightGene = Random.Range(1, 17);
		if (Random.value < 0.5f) RightDownGene = Random.Range(1, 17);
		if (Random.value < 0.5f) LeftDownGene = Random.Range(1, 17);
	}

	public void GenerateAlmostRandomNextGrowthGenes(float growthChanceUp, float growthChanceSide, float growthChanceDown)
	{
		if (Random.value < growthChanceSide) LeftGene = Random.Range(1, 17);
		if (Random.value < growthChanceUp) LeftUpGene = Random.Range(1, 17);
		if (Random.value < growthChanceUp) RightUpGene = Random.Range(1, 17);
		if (Random.value < growthChanceSide) RightGene = Random.Range(1, 17);
		if (Random.value < growthChanceDown) RightDownGene = Random.Range(1, 17);
		if (Random.value < growthChanceDown) LeftDownGene = Random.Range(1, 17);
	}

	public void GenerateFullyRandomCondition1()
	{
		if (HasCondition1)
		{
			Operator1 = (Operators)Random.Range(0, 6);

			if (Random.value < 0.5f)
			{
				Parameter1 = Parameters.number;
				RandomNumber1 = Random.Range(0, 101);
				Parameter2 = (Parameters)Random.Range(1, 17);
			}
			else
			{
				Parameter1 = (Parameters)Random.Range(1, 17);

				if (Random.value < 0.5f)
				{
					Parameter2 = Parameters.number;
					RandomNumber1 = Random.Range(0, 101);
				}
				else
				{
					Parameter2 = (Parameters)Random.Range(1, 17);
				}
			}
		}
	}

	public void GenerateAlmostRandomCondition1(float numberChanceParameter1, float numberChanceParameter2)
	{
		if (HasCondition1)
		{
			Operator1 = (Operators)Random.Range(0, 6);

			if (Random.value < numberChanceParameter1)
			{
				Parameter1 = Parameters.number;
				RandomNumber1 = Random.Range(0, 101);
				Parameter2 = (Parameters)Random.Range(1, 17);
			}
			else
			{
				Parameter1 = (Parameters)Random.Range(1, 17);

				if (Random.value < numberChanceParameter2)
				{
					Parameter2 = Parameters.number;
					RandomNumber1 = Random.Range(0, 101);
				}
				else
				{
					Parameter2 = (Parameters)Random.Range(1, 17);
				}
			}
		}
	}

	public void GenerateFullyRandomCondition2()
	{
		if (HasCondition2)
		{
			BooleanOperator = (BooleanOperators)Random.Range(0, 3);
			Operator2 = (Operators)Random.Range(0, 6);

			if (Random.value < 0.5f)
			{
				Parameter3 = Parameters.number;
				RandomNumber2 = Random.Range(0, 101);
				Parameter4 = (Parameters)Random.Range(1, 17);
			}
			else
			{
				Parameter3 = (Parameters)Random.Range(1, 17);

				if (Random.value < 0.5f)
				{
					Parameter4 = Parameters.number;
					RandomNumber2 = Random.Range(0, 101);
				}
				else
				{
					Parameter4 = (Parameters)Random.Range(1, 17);
				}
			}
		}
	}

	public void GenerateAlmostRandomCondition2(float numberChanceParameter3, float numberChanceParameter4)
	{
		if (HasCondition1)
		{
			Operator1 = (Operators)Random.Range(0, 6);

			if (Random.value < numberChanceParameter3)
			{
				Parameter1 = Parameters.number;
				RandomNumber1 = Random.Range(0, 101);
				Parameter2 = (Parameters)Random.Range(1, 17);
			}
			else
			{
				Parameter1 = (Parameters)Random.Range(1, 17);

				if (Random.value < numberChanceParameter4)
				{
					Parameter2 = Parameters.number;
					RandomNumber1 = Random.Range(0, 101);
				}
				else
				{
					Parameter2 = (Parameters)Random.Range(1, 17);
				}
			}
		}
	}

	public void GenerateRandomIfTrueAction()
	{
		IfTrue = (Actions)Random.Range(0, 4);
		NextGeneIfTrue = Random.Range(1, 17);
	}
	#endregion

	#region Mutation Methods
	public void Mutate()
	{
		if (Random.Range(0, 100) > 5) LeftGene = Random.Range(0, 17);
		if (Random.Range(0, 100) > 5) LeftUpGene = Random.Range(0, 17);
		if (Random.Range(0, 100) > 5) RightUpGene = Random.Range(0, 17);
		if (Random.Range(0, 100) > 5) RightGene = Random.Range(0, 17);
		if (Random.Range(0, 100) > 5) RightDownGene = Random.Range(0, 17);
		if (Random.Range(0, 100) > 5) LeftDownGene = Random.Range(0, 17);
		if (Random.Range(0, 100) > 5) HasCondition1 = (Random.value > 0.5f);
		if (Random.Range(0, 100) < 5 && HasCondition1) Parameter1 = (Parameters)Random.Range(0, 17);
		if (Random.Range(0, 100) < 5 && HasCondition1) Parameter2 = (Parameters)Random.Range(0, 17);
	}
	#endregion
	#endregion
}