using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class GeneratedNumbersView : MonoBehaviour
    {
        private int[] _numbers;

        private void Update()
        {
            _numbers = GameObject.Find(StaticLiterals.EquationGeneratorName).GetComponent<EquationGenerator>().numbers;
            this.GetComponent<TextMeshProUGUI>().SetText(string.Join("   ", _numbers));
        }
    }
}
