using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            GameManager.Instance.IsPlayerDead = true;
            GameManager.Instance.LoadLevel("OverScreen");
        }
    }
}
