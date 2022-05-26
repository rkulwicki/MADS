using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI
{
    class SolutionView : MonoBehaviour
    {
        private int _solution;

        private void Update()
        {
            _solution = GameObject.Find(StaticLiterals.EquationGeneratorName).GetComponent<EquationGenerator>().solution;
            this.GetComponent<TextMeshProUGUI>().SetText(_solution.ToString());
        }
    }
}

