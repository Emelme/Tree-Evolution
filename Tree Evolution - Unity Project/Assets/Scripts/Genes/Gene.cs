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

	public int parameter1;
	public Operator operator1;
	public int parameter2;
	public BooleanOperator booleanOperator;
	public int parameter3;
	public Operator operator2;
	public int parameter4;


	public enum Operator
	{
		equal,
		notEqual,
		lessThen,
		notLessThen,
		greaterThan,
		notGreaterThan,
		lessThanOrEqual,
		notLessThanOrEqual,
		greaterThanOrEqualOrEqual,
		notGreaterThanOrEqualOrEqual
	}

	public enum BooleanOperator
	{
		AND,
		OR,
		XOR
	}
}
