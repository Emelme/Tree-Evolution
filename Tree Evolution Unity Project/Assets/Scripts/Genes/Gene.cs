using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Gene
{
	public int number;

	public int leftGene;
	public int leftUpGene;
	public int rightUpGene;
	public int rightGene;
	public int rightDownGene;
	public int leftDownGene;

	public bool hasCondition1;
	public int parameter1;
	public Operators operator1;
	public int parameter2;
	public bool hasCondition2;
	public BooleanOperators booleanOperator;
	public int parameter3;
	public Operators operator2;
	public int parameter4;
	public int nextGeneIfTrue;

	public enum Parameters
	{
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
		energyOfSunGetsSprout,
		number
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
		AND,
		OR,
		XOR
	}
}
