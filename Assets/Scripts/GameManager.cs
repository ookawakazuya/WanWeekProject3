using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("惑星プレハブ")]
    public GameObject[] planetPrefabs;

    [Header("スコア設定（各レベルの得点）")]
    public int[] levelScores = { 10, 20, 40, 80, 160, 320 ,400};

    [Header("UI")]
    [SerializeField] Text scoreText;

    private int score = 0;

    GameObject mergeEffectPrefab;

    void Awake()
    {
        Instance = this;
    }


    public void SpawnMergeEffect(Vector3 pos)
    {
        if (mergeEffectPrefab != null)
            Instantiate(mergeEffectPrefab, pos, Quaternion.identity);
    }

    //  レベルに応じたスコアを返す
    public int GetScoreByLevel(int level)
    {
        if (level < levelScores.Length)
            return levelScores[level];
        else
            return levelScores[levelScores.Length - 1]; // 最後の値を使う（最大レベル超え対策）
    }

    // スコア加算
    public void AddScore(int amount)
    {
        score += amount;

        if (scoreText != null)
            scoreText.text = "SCORE : " + score;
    }

    //  スコア取得（リザルト用）
    public int GetScore()
    {
        return score;
    }

    //  ゲームオーバー時のスコア保存（前回の仕組み）
    public void OnGameOver()
    {
        PlayerPrefs.SetInt("LastScore", score);
        SceneController.Instance.GoToResult();
    }
}

