using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Insttree : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public float spawnDelay = 3f;

    void Start()
    {
        // ��������Ԥ�����Э��
        StartCoroutine(SpawnPrefabCoroutine());
    }

    // Э�̺���
    IEnumerator SpawnPrefabCoroutine()
    {
        while (true)
        {
            // ����Ԥ����
            Instantiate(prefabToSpawn, transform.position, Quaternion.identity);

            // �ȴ�ָ�����ӳ�ʱ��
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
