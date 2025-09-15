using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject prefabObject;
    List<GameObject> spawndObject = new List<GameObject>();
    public int maxunits = 10; // 추후 시스템 연결
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void unitSpawnScript()
    {
        if (spawndObject.Count < maxunits)
        {
            //Debug.Log("test1");
            float spawnPointX = Random.Range(-2.3f, 2.3f);
            float spawnPointY = Random.Range(-4.7f, 3.3f);
            Vector2 spawnPoint = new Vector2(spawnPointX, spawnPointY);
            GameObject newObject = Instantiate(prefabObject, spawnPoint, Quaternion.identity);

            spawndObject.Add(newObject);
        }
        else
        {
            Debug.Log("왜 하나밖에 없는데 왜");
        }
    }
}
