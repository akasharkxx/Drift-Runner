using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> coinAsChild;
    [SerializeField] private float positionOnX;

    private void Start()
    {
        if (gameObject.name != "cube0")
        {
            SpawnCoin();
        }
    }

    public void SpawnCoin()
    {
        float[] xPosition = new float[] { -positionOnX, 0f, positionOnX };
        
        float newX = xPosition[Mathf.RoundToInt(Random.Range(0, 3))];
        
        for (int i = 0; i < coinAsChild.Count; i++)
        {
            coinAsChild[i].SetActive(true);
            Vector3 newPosition = coinAsChild[i].transform.localPosition + new Vector3(newX, 0f, 0f);
            coinAsChild[i].transform.localPosition = newPosition;
        }
    }
}
