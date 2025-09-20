using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    List<GameObject> spawndObject = new List<GameObject>();
    public GameObject StoreUI;
    public GameObject SettingUI;
    public GameObject InfoUI;
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
    public void TapOpen(GameObject TapUi)
    {
        TapUi.SetActive(true);
    }
    public void TapOff(GameObject TapUi)
    {
        TapUi.SetActive(false);
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
        //EventSystem.inspector.InputSystemUiInputModule.ActionAsset 을 none 하니깐 터치시 골드도 나오고 버튼 도 눌림
        //이제 버튼 누를때도 골드 나오는것만 해결하면 됨. 일단 IsPointerOverGameObject() 충돌 문제는 이해 못하므로 사용X
        //이후 코드는 챗지피티를 참고 (이해 못 했으니 다시 공부하라는 뜻)
        Vector2 mousePointer = Mouse.current.position.ReadValue();
        Vector2 gamePointer = Camera.main.ScreenToWorldPoint(mousePointer);
        RaycastHit2D clickPointer = Physics2D.Raycast(gamePointer, Vector2.zero);
        string clickedObjectName = clickPointer.collider.gameObject.name;
        bool isMainScreen = clickedObjectName == "yellowGreen_0";
        bool isUi = !StoreUI.activeSelf && !SettingUI.activeSelf && !InfoUI.activeSelf;

        if (!context.performed) { return; }

        if (isMainScreen && isUi)
        {
            gameMoney += 1;
            Debug.Log(isUi);
        }
    }
}
