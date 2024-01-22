using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
	public Transform[] birthList;
    public GameObject[] randomList;

    public float firstBirthTime;
    public float birthTime = 3;
    public float birthRangeTime = 1;

    public float nextBirthTime;

    // Use this for initialization
	void Start ()
	{
		nextBirthTime = Time.time + firstBirthTime;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Time.time > nextBirthTime)
		{
            RandomNextTime();
            CreateChild();
		}
	}

    private void RandomNextTime()
    {
        nextBirthTime = Time.time + Random.Range(birthTime - birthRangeTime, birthTime + birthRangeTime);
    }

    private void CreateChild()
    {
	    Transform birth = GetBirthPoint();
        Instantiate(GetChildObj(), birth.position, birth.rotation);
    }

    private Transform GetBirthPoint()
    {
	    int idx = Random.Range(0, birthList.Length);
	    Transform birth = birthList[idx];
	    return birth;
    }

    private GameObject GetChildObj()
    {
	    int idx = Random.Range(0, randomList.Length);
	    GameObject child = randomList[idx];
	    return child;
    }
}
