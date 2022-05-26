using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EquationGenerator : MonoBehaviour
{

    public int size;
    public Vector2Int range;

    // these should be read-only but are public for the Unity IDE's sake
    public int[] numbers;
    public int[] orderedNumbers;
    public MathOperatorsEnum[] operators;
    public int solution;

    private System.Random random;
    private MathOperatorsEnum[] validOperators;
    void Start()
    {
        validOperators = new MathOperatorsEnum[] {
            MathOperatorsEnum.ADDITION,
            MathOperatorsEnum.SUBTRACTION,
            MathOperatorsEnum.MULTIPLICATION,
            MathOperatorsEnum.DIVISION,
        };
    }

    public void Generate()
    {
        random = new System.Random();
        if (size < 2)
            throw new Exception("Size must be greater than 1.");

        var validEquation = false;
        while (!validEquation)
        {
            var tempNumbers = new int[size];
            var tempOperators = new MathOperatorsEnum[size - 1];

            var tempSolution = random.Next(range.x, range.y);
            tempNumbers[0] = tempSolution;

            for (int i = 1; i < size; i++)
            {
                var number = random.Next(range.x, range.y);
                var n = random.Next(0, validOperators.Length);
                var op = validOperators[n];

                if (op == MathOperatorsEnum.DIVISION)
                {
                    //do a bunch of extra stuff for division because we want integers.
                    if (number == 0)
                        number = 1; //TODO -- do this better

                    if (tempSolution % number != 0)
                    {
                        for (int j = range.x; j < (Math.Abs(range.x) + Math.Abs(range.y) + 1); j++)
                        {
                            if (j == 0 || j == -1 || j == 1)
                                continue;
                            if (tempSolution % j == 0)
                            {
                                number = j;
                                break;
                            }
                            if (j == (Math.Abs(range.x) + Math.Abs(range.y)))
                                op = MathOperatorsEnum.ADDITION; // TODO -- do this better.  
                        }
                    }
                }

                switch (op)
                {
                    case MathOperatorsEnum.ADDITION:
                        tempSolution += number;
                        break;
                    case MathOperatorsEnum.SUBTRACTION:
                        tempSolution -= number;
                        break;
                    case MathOperatorsEnum.MULTIPLICATION:
                        tempSolution *= number;
                        break;
                    case MathOperatorsEnum.DIVISION:
                        tempSolution /= number;
                        break;
                }

                tempNumbers[i] = number;
                tempOperators[i - 1] = op;
            }

            var rando = new System.Random();
            orderedNumbers = tempNumbers;
            numbers = tempNumbers.OrderBy(x => rando.Next()).ToArray();
            operators = tempOperators;
            solution = tempSolution;
            validEquation = true;
        }
    }
}
public enum MathOperatorsEnum { ADDITION, SUBTRACTION, MULTIPLICATION, DIVISION }
