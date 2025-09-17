using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject prefabObject;
    public GameObject prefabObject2;
    public GameObject prefabObject3;
    public GameObject prefabObject4;
    public GameObject prefabObject5;
    public GameObject prefabObject6;
    List<GameObject> spawndObject = new List<GameObject>();
    public int maxunits = 10; // 추후 시스템 연결
    public int currentUnits;
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
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
            currentUnits = spawndObject.Count;
            
        }
        else
        {
            Debug.Log("유닛 수가 최대입니다.");
        }
    }
    public void unitSpawnScript2()
    {
        if (spawndObject.Count < maxunits)
        {
            //Debug.Log("test1");
            float spawnPointX = Random.Range(-2.3f, 2.3f);
            float spawnPointY = Random.Range(-4.7f, 3.3f);
            Vector2 spawnPoint = new Vector2(spawnPointX, spawnPointY);
            GameObject newObject = Instantiate(prefabObject2, spawnPoint, Quaternion.identity);

            spawndObject.Add(newObject);
            currentUnits = spawndObject.Count;
        }
        else
        {
            Debug.Log("유닛 수가 최대입니다.");
        }
    }
    public void unitSpawnScript3()
    {
        if (spawndObject.Count < maxunits)
        {
            //Debug.Log("test1");
            float spawnPointX = Random.Range(-2.3f, 2.3f);
            float spawnPointY = Random.Range(-4.7f, 3.3f);
            Vector2 spawnPoint = new Vector2(spawnPointX, spawnPointY);
            GameObject newObject = Instantiate(prefabObject3, spawnPoint, Quaternion.identity);

            spawndObject.Add(newObject);
            currentUnits = spawndObject.Count;
        }
        else
        {
            Debug.Log("유닛 수가 최대입니다.");
        }
    }
    public void unitSpawnScript4()
    {
        if (spawndObject.Count < maxunits)
        {
            //Debug.Log("test1");
            float spawnPointX = Random.Range(-2.3f, 2.3f);
            float spawnPointY = Random.Range(-4.7f, 3.3f);
            Vector2 spawnPoint = new Vector2(spawnPointX, spawnPointY);
            GameObject newObject = Instantiate(prefabObject4, spawnPoint, Quaternion.identity);

            spawndObject.Add(newObject);
            currentUnits = spawndObject.Count;
        }
        else
        {
            Debug.Log("유닛 수가 최대입니다.");
        }
    }
    public void unitSpawnScript5()
    {
        if (spawndObject.Count < maxunits)
        {
            //Debug.Log("test1");
            float spawnPointX = Random.Range(-2.3f, 2.3f);
            float spawnPointY = Random.Range(-4.7f, 3.3f);
            Vector2 spawnPoint = new Vector2(spawnPointX, spawnPointY);
            GameObject newObject = Instantiate(prefabObject5, spawnPoint, Quaternion.identity);

            spawndObject.Add(newObject);
            currentUnits = spawndObject.Count;
        }
        else
        {
            Debug.Log("유닛 수가 최대입니다.");
        }
    }
    public void unitSpawnScript6()
    {
        if (spawndObject.Count < maxunits)
        {
            //Debug.Log("test1");
            float spawnPointX = Random.Range(-2.3f, 2.3f);
            float spawnPointY = Random.Range(-4.7f, 3.3f);
            Vector2 spawnPoint = new Vector2(spawnPointX, spawnPointY);
            GameObject newObject = Instantiate(prefabObject6, spawnPoint, Quaternion.identity);

            spawndObject.Add(newObject);
            currentUnits = spawndObject.Count;
        }
        else
        {
            Debug.Log("유닛 수가 최대입니다.");
        }
    }
}
