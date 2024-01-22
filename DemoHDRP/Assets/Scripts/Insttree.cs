using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Insttree : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public float spawnDelay = 3f;

    void Start()
    {
        // 启动生成预制体的协程
        StartCoroutine(SpawnPrefabCoroutine());
    }

    // 协程函数
    IEnumerator SpawnPrefabCoroutine()
    {
        while (true)
        {
            // 生成预制体
            Instantiate(prefabToSpawn, transform.position, Quaternion.identity);

            // 等待指定的延迟时间
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
