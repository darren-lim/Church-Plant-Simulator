using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    public static NPCSpawner current;
    //List of different NPCs to spawn. CANNOT BE NULL
    //Put all of the NPCs here from the inspector, or can add later in code
    public GameObject NPCObject;
    //pool of NPCs to store in
    List<GameObject> pooledNPCObjects;
    //multiply by list length to store that many NPCs
    public int EachNPCPoolAmount = 50;

    // Start is called before the first frame update
    void Awake()
    {
        if (current == null)
            current = this;
        else
        {
            Destroy(this.gameObject);
            return;
        }
    }

    private void Start()
    {
        //Initialize a set amount of each NPCs
        if (NPCObject == null)
        {
            Debug.LogError("BulletObjects list is empty. Fill with Bullets.");
            return;
        }
        for (int k = 0; k < EachNPCPoolAmount; k++)
        {
            GameObject obj = (GameObject)Instantiate(NPCObject);
            obj.SetActive(false);
            pooledNPCObjects.Add(obj);
        }
    }
    //gets an object from the list pooledObjects.
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledNPCObjects.Count; ++i)
        {
            if (pooledNPCObjects[i] != null && !pooledNPCObjects[i].activeInHierarchy)
            {
                return pooledNPCObjects[i];
            }
        }
        return null;
    }

    /// <summary>
    /// Pools more NPCs into the scene when there are not enough bullets
    /// </summary>
    /// <param name="listIndex"></param>
    /// <returns>none</returns>
    public GameObject PoolMoreNPCs()
    {
        GameObject obj = (GameObject)Instantiate(NPCObject);
        obj.SetActive(false);
        pooledNPCObjects.Add(obj);
        return obj;
    }
}
