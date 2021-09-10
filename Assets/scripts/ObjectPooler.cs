using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public GameObject pooledObject;
    public int numOfObject;

    private List<GameObject> pooledObjects;

    void Start()
    {
        pooledObjects = new List<GameObject>();

        for(int i=0; i< numOfObject; i++)
        {
            GameObject Obj = (GameObject)Instantiate(pooledObject);
            Obj.SetActive(false);
            pooledObjects.Add(Obj);
        }
    }
        
    public GameObject GetPooledGameObject()
    {
        for(int i =0; i<pooledObjects.Count;i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        GameObject Obj = (GameObject)Instantiate(pooledObject);
        Obj.SetActive(false);
        pooledObjects.Add(Obj);
        return Obj;
    }
}
