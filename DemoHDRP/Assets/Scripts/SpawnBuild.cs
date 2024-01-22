using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBuild : MonoBehaviour
{
    public Vector3 offsetSize = new Vector3(0, 33.84f, 0);
    public Vector3 moveDir;
    public float moveSpeed;
    public Transform root;
    public GameObject temp; 
    public int maxCount = 2;

    private List<GameObject> childList = new List<GameObject>();
    private bool doing = false;
    
// Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < maxCount; i++)
        {
            AddItem();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        root.localPosition += Time.deltaTime * moveDir * moveSpeed;
        // if (Vector3.Distance(root.position, nextPos) <= 3f)
        // {
        //     UpdateNextSpawnPoint();
        //     GameObject go = childList[0];
        //     Destroy(go);
        //     childList.RemoveAt(0);
        //     AddItem();
        // }
    }

    public GameObject AddItem()
    {
        GameObject last = GetLastChild();
        Vector3 pos;
        if (last == null)
        {
            pos = temp.transform.localPosition;
        }
        else
        {
            pos = last.transform.localPosition + offsetSize;
        }
        GameObject go = GameObject.Instantiate(temp, root);
        go.transform.localPosition = pos;
        go.SetActive(true);
        childList.Add(go);
        return go;
    }

    private GameObject GetLastChild()
    {
        int index = childList.Count - 1;
        if (index < 0)
        {
            return null;
        }

        return childList[index];
    }
}
