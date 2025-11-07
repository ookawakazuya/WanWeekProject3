using UnityEngine;

public class MergeEffect : MonoBehaviour
{
    [SerializeField] float lifeTime = 1f;

    void Start()
    {
        // õ–½Œã‚É©“®íœ
        Destroy(gameObject, lifeTime);
    }
}
