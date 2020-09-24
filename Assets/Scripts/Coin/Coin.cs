using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float destroyTime;

    private Animator animatorOnCoinGFX;

    private void Start()
    {
        animatorOnCoinGFX = GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.AddCollectedCoins(1);
            animatorOnCoinGFX.SetBool("isCollected", true);
            Destroy(gameObject, destroyTime);
        }
    }
}
