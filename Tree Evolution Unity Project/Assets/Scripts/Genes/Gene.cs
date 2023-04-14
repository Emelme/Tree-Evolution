using UnityEngine;
using static Gene;

public class Gene
{
	#region Data
	#region Properties
	public int Number
	{
		get
		{
			return Number;
		}
		set
		{
			if (value < 1 || value > 16)
			{
				Number = 1;
			}
			else
			{
				Number = value;
			}
		}
	}

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
	public void GenerateFullyRandomValues()
	{
		LeftGene = Random.Range(1, 17);
		LeftUpGene = Random.Range(1, 17);
		RightUpGene = Random.Range(1, 17);
		RightGene = Random.Range(1, 17);
		RightDownGene = Random.Range(1, 17);
		LeftDownGene = Random.Range(1, 17);

		HasCondition1 = (Random.value < 0.5f);

		if (HasCondition1)
		{
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

				}
			}

			if (Random.value < 0.5f)
			{
				Parameter1 = Parameters.number;
			}
			else
			{
				Parameter1 = (Parameters)Random.Range(1, 17);

				if ()
				{
					Parameter2 = Random.Range(0, 64);
					parameter2 = Parameters.number;
				}
				else
				{
					parameter2 = (Parameters)Random.Range(0, 16);
				}
			}
		}
		Parameter2 = (Parameters)Random.Range(0, 17);

		HasCondition2 = (HasCondition1 = true && Random.value < 0.5f);
	}

	public void GenerateFullyRandomNextGrowthGene()
	{
		LeftGene = Random.Range(1, 17);
		LeftUpGene = Random.Range(1, 17);
		RightUpGene = Random.Range(1, 17);
		RightGene = Random.Range(1, 17);
		RightDownGene = Random.Range(1, 17);
		LeftDownGene = Random.Range(1, 17);
	}

	public v
	#endregion