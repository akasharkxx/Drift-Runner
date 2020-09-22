using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> coinAsChild;
    [SerializeField] private float positionOnX;

    private void Start()
    {
        float[] xPosition = new float[] { -positionOnX, 0f, positionOnX};

        if (Random.Range(0, 2) > 1)
        {
        float newX = xPosition[Mathf.RoundToInt(Random.Range(0, 2))];
            for (int i = 0; i < coinAsChild.Count; i++)
            {
                coinAsChild[i].SetActive(true);
                Vector3 newPosition = new Vector3(newX, 0f, 0f);
                coinAsChild[i].transform.localPosition = coinAsChild[i].transform.localPosition + newPosition;
            }
        }
    }
}
