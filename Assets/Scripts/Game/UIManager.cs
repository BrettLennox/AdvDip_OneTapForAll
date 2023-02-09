using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    #region Variables
    [SerializeField] private TextMeshProUGUI _scoreText;
    #endregion

    // Update is called once per frame
    void Update()
    {
        UpdateText(_scoreText, ScoreManager.instance.TotalScore.ToString());
    }

    private void UpdateText(TextMeshProUGUI text, string textToFill)
    {
        text.text = textToFill;
    }
}
