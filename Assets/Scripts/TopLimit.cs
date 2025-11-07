using UnityEngine;

public class TopLimit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ˜f¯‚ªG‚ê‚½‚çƒQ[ƒ€ƒI[ƒo[
        if (collision.CompareTag("Planet"))
        {
            Debug.Log("TopLimitG‚ê‚½ ¨ GameManager‚Í " + GameManager.Instance);
            GameManager.Instance.OnGameOver();
        }
    }
}
