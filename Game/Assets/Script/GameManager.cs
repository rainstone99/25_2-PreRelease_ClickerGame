using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    List<GameObject> spawndObject = new List<GameObject>();
    public static int maxunits = 10; // 추후 시스템 연결
    public static int currentUnits;
    public void unitSpawnScript(GameObject prefab)
    {
        if (spawndObject.Count < maxunits)
        {
            //Debug.Log("test1");
            float spawnPointX = Random.Range(-2.3f, 2.3f);
            float spawnPointY = Random.Range(-4.7f, 3.3f);
            Vector2 spawnPoint = new Vector2(spawnPointX, spawnPointY);
            GameObject newObject = Instantiate(prefab, spawnPoint, Quaternion.identity);

            spawndObject.Add(newObject);
            currentUnits = spawndObject.Count;
            
        }
        else
        {
            Debug.Log("유닛 수가 최대입니다.");
        }
    }
}
