using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public ObjectPooler coinpool;

    public float distanceBetweenCoin;

    public void SpawnCoin(Vector3 startPosition)
    {
       /* int numberofcoins = (int)Random.Range(3f, platformwidths);

        for (int i = 0; i < numberofcoins; i++)
        {
         GameObject coin = coinpool.GetPooledGameObject();
        coin.transform.position = new Vector3(position.x + i, position.y, position.z);
        coin.SetActive(true);
        }*/

        GameObject coin1 = coinpool.GetPooledGameObject();
        coin1.transform.position = new Vector3(startPosition.x,startPosition.y + 1f,startPosition.z);
        coin1.SetActive(true);

        GameObject coin2 = coinpool.GetPooledGameObject();
        coin2.transform.position = new Vector3(startPosition.x - distanceBetweenCoin, startPosition.y + 1f, startPosition.z);
        coin2.SetActive(true);

        GameObject coin3 = coinpool.GetPooledGameObject();
        coin3.transform.position = new Vector3(startPosition.x + distanceBetweenCoin, startPosition.y + 1f, startPosition.z); ;
        coin3.SetActive(true);

    }
}
