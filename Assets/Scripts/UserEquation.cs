using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class UserEquation : MonoBehaviour
    {
        //these should be read-only but are public for the Unity IDE's sake
        public int[] numberChoices;
        public MathOperatorsEnum[] operators;
        public int solution;

        private int _size;
        private Vector2Int _range;
        private int[] _numbersToChooseFrom;

        private GameObject _equationGenerator;

        private void Start()
        {
            _equationGenerator = GameObject.Find(StaticLiterals.EquationGeneratorName);
            _size = _equationGenerator.GetComponent<EquationGenerator>().size;
            _range = _equationGenerator.GetComponent<EquationGenerator>().range;
            _numbersToChooseFrom = _equationGenerator.GetComponent<EquationGenerator>().numbers;

            numberChoices = new int[_size];
            operators = new MathOperatorsEnum[_size - 1];
        }

        private void Update()
        {
            RestrictUserChoices();
        }

        public void RestrictUserChoices()
        {
            for (int i = 0; i < _size; i++)
            {
                if(_numbersToChooseFrom.Contains(numberChoices[i]))
                    //todo create enum of the number choices?
            }
        }
    }
}
