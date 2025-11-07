using UnityEngine;

public class Planet : MonoBehaviour
{
    public int planetLevel = 0;   // 惑星レベル（0 = 水星, 1 = 火星, ...）
    private bool hasMerged = false;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Planet other = collision.gameObject.GetComponent<Planet>();

        // 同レベル同士で合体判定
        if (other != null && other.planetLevel == planetLevel)
        {
            if (hasMerged || other.hasMerged) return;
            hasMerged = true;
            other.hasMerged = true;

            MergeWith(other);
        }
    }

    void MergeWith(Planet other)
    {
        Vector3 spawnPos = (transform.position + other.transform.position) / 2f;
        spawnPos.y += 0.2f;

        int nextLevel = planetLevel + 1;

        // 次の惑星が存在する場合のみ生成
        if (nextLevel < GameManager.Instance.planetPrefabs.Length)
        {
            GameObject newPlanet = Instantiate(GameManager.Instance.planetPrefabs[nextLevel], spawnPos, Quaternion.identity);
            newPlanet.GetComponent<Planet>().planetLevel = nextLevel;

            // ちょっと上に弾ませる
            Rigidbody2D newRb = newPlanet.GetComponent<Rigidbody2D>();
            newRb.AddForce(Vector2.up * 2f, ForceMode2D.Impulse);

            // 合体演出を出す
            GameManager.Instance.SpawnMergeEffect(spawnPos);

            //  スコア加算処理（レベルに応じて）
            int score = GameManager.Instance.GetScoreByLevel(planetLevel);
            GameManager.Instance.AddScore(score);
        }

        // 元の惑星を削除
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
