using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObj : MonoBehaviour
{
    public List<Transform> birthList;
    public List<GameObject> randomList;
    
    // Start is called before the first frame update
    void Start()
    {
        int count = Random.Range(1, 3);
        for (int i = 0; i < count; i++)
        {
            int idx = Random.Range(0, birthList.Count);
            Transform birth = birthList[idx];
            birthList.RemoveAt(idx);
            
            idx = Random.Range(0, randomList.Count);
            GameObject go = Instantiate(randomList[idx], birth);
            go.transform.localPosition = Vector3.zero;
            //go.transform.rotation = birth.rotation;
            
            randomList.RemoveAt(idx);
        }
    }
}
