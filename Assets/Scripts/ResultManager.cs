using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    [Header("スコア表示UI")]
    [SerializeField] private Text scoreText;

    void Start()
    {
        // GameManagerで保存されたスコアを読み込み
        int lastScore = PlayerPrefs.GetInt("LastScore", 0);

        // スコアをUIに反映
        if (scoreText != null)
        {
            scoreText.text = "SCORE : " + lastScore.ToString();
        }
        else
        {
            Debug.LogWarning("scoreTextが未設定です。ResultManagerにUI Textを割り当ててください。");
        }
    }
}
