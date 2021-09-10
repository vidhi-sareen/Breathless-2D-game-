using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenrator : MonoBehaviour
{
    public GameObject thePlatform;

    public Transform generationPoint;
    public float distance;


    public float distanceGapMin;
    public float distanceGapMax;

    private int platformSelector;
    private float[] platformwidths;

    public ObjectPooler[] theObjectPools;

    private float minheight;
    private float maxheight;

    public Transform maxheigthpt;
    public float maxheightchange;
    private float heightchange;

    private CoinGenerator thecoinGenerator;

    public float randomSpikethreshold;
    public ObjectPooler SpikePool;

    void Start()
    {

        platformwidths = new float[theObjectPools.Length];
        for(int i=0; i < theObjectPools.Length; i++)
        {
            platformwidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }

        minheight = transform.position.y;
        maxheight = maxheigthpt.position.y;

       thecoinGenerator = FindObjectOfType<CoinGenerator>();
    }

    
    void Update()
    {
        if(transform.position.x < generationPoint.position.x)
        {
            distance = Random.Range(distanceGapMin, distanceGapMax);

            platformSelector = Random.Range(0, theObjectPools.Length);

            heightchange = transform.position.y + Random.Range(maxheightchange, -maxheightchange);

            if(heightchange > maxheight)
            {
                heightchange = maxheight;

            }else if(heightchange < minheight)
            {
                heightchange = minheight;
            }


            transform.position = new Vector3(transform.position.x + (platformwidths[platformSelector] / 2) + distance,
                heightchange,
                transform.position.z); 


            GameObject newplateform = theObjectPools[platformSelector].GetPooledGameObject();

            newplateform.transform.position = transform.position;
            newplateform.transform.rotation = transform.rotation;
            newplateform.SetActive(true);

            thecoinGenerator.SpawnCoin(new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z));
            //thecoinGenerator.SpawnCoin(new Vector3(
              //  transform.position.x, platformwidths[platformSelector],0));

            if(Random.Range(0f, 100f) < randomSpikethreshold)
            {
                GameObject newSpike = SpikePool.GetPooledGameObject();

                float spikeXPosition = Random.Range(-platformwidths[platformSelector] / 2f + 1f, platformwidths[platformSelector] / 2f - 1f);

                Vector3 spikePosition = new Vector3(0f, 2f, 0f);
                newSpike.transform.position = transform.position + spikePosition;
                newSpike.transform.rotation = transform.rotation;
                newSpike.SetActive(true);
            }

            transform.position = new Vector3(transform.position.x + (platformwidths[platformSelector] / 2),
                transform.position.y,
                transform.position.z);

        }
    }
}
