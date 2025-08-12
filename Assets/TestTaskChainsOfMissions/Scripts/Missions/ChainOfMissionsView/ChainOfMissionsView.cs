using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChainOfMissionsView : MonoBehaviour
{
    [field: SerializeField] public Button EndMissionButton { get; private set; }
    [SerializeField] private TextMeshProUGUI _chainNumberText;

    public void Initialize(string chainNumber)
    {
        _chainNumberText.SetText(chainNumber + " Chain");
    }
}
