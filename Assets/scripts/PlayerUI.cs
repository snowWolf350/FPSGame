using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI promptText;

    public void UpdateText(string displayText)
    {
        promptText.text = displayText;
    }
}
