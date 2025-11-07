using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [SerializeField] float lifeTime = 0.6f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}
