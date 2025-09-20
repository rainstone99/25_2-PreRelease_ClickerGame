using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    List<GameObject> spawndObject = new List<GameObject>();
    public static int maxunits = 10; // 추후 시스템 연결
    public static int currentUnits;
    public static int gameMoney;
    public static int TotalGainGold;
    public void Start()
    {
        spawndObject.Clear();
        currentUnits = 0;
        gameMoney = 0;
        TotalGainGold = 0;
        StopCoroutine("CreatMoneyTime");
        StartCoroutine("CreatMoneyTime");
    }
    public void UnitSpawnScript(GameObject prefab)
    {
        UnitScript unitScript = prefab.GetComponent<UnitScript>();
        if (spawndObject.Count < maxunits && gameMoney >= unitScript.UnitPrice)
        {
            //Debug.Log("test1");
            float spawnPointX = Random.Range(-2.3f, 2.3f);
            float spawnPointY = Random.Range(-4.7f, 3.3f);
            Vector2 spawnPoint = new Vector2(spawnPointX, spawnPointY);
            GameObject newObject = Instantiate(prefab, spawnPoint, Quaternion.identity);
            spawndObject.Add(newObject);
            currentUnits = spawndObject.Count;
        }
        else if (gameMoney < unitScript.UnitPrice)
        {
            Debug.Log("골드가 부족합니다."); //추후 팝업창으로 수정
        }
        else if (spawndObject.Count >= maxunits)
        {
            Debug.Log("유닛 수가 최대입니다.");
        }
    }
    IEnumerator CreatMoneyTime()
    {
        while (true)
        {
            GameManager.gameMoney = CreatMoney(TotalGainGold);
            yield return new WaitForSeconds(1f);
        }
    }
    int CreatMoney(int TotalGainGold)
    {
        GameManager.gameMoney = GameManager.gameMoney + TotalGainGold;
        return GameManager.gameMoney;
    }
    public void TouchGold(InputAction.CallbackContext context)
    {
        if (context.performed && EventSystem.current.IsPointerOverGameObject())
        {
            gameMoney += 1;
        }
    }
}
