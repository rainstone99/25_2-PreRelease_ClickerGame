using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    static List<GameObject> spawndObject = new List<GameObject>();
    static Dictionary<GameObject, List<GameObject>> unitInstancesByType = new Dictionary<GameObject, List<GameObject>>();
    public GameObject StoreUI;
    public GameObject SettingUI;
    public GameObject InfoUI;
    public static int maxUnits; // 추후 시스템 연결
    public static int currentUnits;
    public static int gameMoney;
    public static int TotalGainGold;
    public static int touchGainGold;
    public static int touchUpgradeLevel;
    public static int touchUpgradePrice;
    public static int maxLimitLevel;
    public static int maxLimitUpgradePrice;
    public void Start()
    {
        spawndObject.Clear();
        unitInstancesByType.Clear();
        maxUnits = 3;
        currentUnits = 0;
        gameMoney = 50000;
        TotalGainGold = 0;
        touchGainGold = 1;
        maxLimitLevel = 1;
        maxLimitUpgradePrice = 500 * maxLimitLevel;
        touchUpgradeLevel = 1;
        touchUpgradePrice = 500 * touchUpgradeLevel;
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
        if (spawndObject.Count < maxUnits && gameMoney >= unitScript.UnitPrice)
        {
            //Debug.Log("test1");
            float spawnPointX = Random.Range(-2.3f, 2.3f); //랜덤 x좌표
            float spawnPointY = Random.Range(-4.7f, 3.3f); //랜덤 y좌표
            Vector2 spawnPoint = new Vector2(spawnPointX, spawnPointY); //랜덤 좌표
            GameObject newObject = Instantiate(prefab, spawnPoint, Quaternion.identity); //(프리펩, 랜덤 좌표, 각도, 오브젝트 위치(미설정)) 오브젝트 생성
            spawndObject.Add(newObject); //리스트에 추가(개수 계산목적) 
            gameMoney -= unitScript.UnitPrice; // 구매시 유닛 가격만큼골드 제거
            currentUnits = spawndObject.Count; //현재 유닛 수 동기화
            //여기부터 지피티 작품
            if (!unitInstancesByType.ContainsKey(prefab))
            {
                unitInstancesByType[prefab] = new List<GameObject>();
            }
            unitInstancesByType[prefab].Add(newObject);
            //여기까지
        }
        else if (gameMoney < unitScript.UnitPrice)
        {
            Debug.Log("골드가 부족합니다."); //추후 팝업창으로 수정
        }
        else if (spawndObject.Count >= maxUnits)
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
            gameMoney += touchGainGold;
            //Debug.Log(isUi);
        }
    }
    public void MaxLimitUpgrade()
    {
        if (gameMoney >= maxLimitUpgradePrice)
        {
            maxUnits += 1;
            gameMoney -= 500 * maxLimitLevel;
            maxLimitLevel++;
            maxLimitUpgradePrice = 500 * maxLimitLevel;
        }
        else
        {
            Debug.Log("골드가 부족합니다.");
        }
    }
    public void TouchGoldUpgrade()
    {
        if (gameMoney >= touchUpgradePrice)
        {
            int upgrade = (touchUpgradeLevel / 3) + 1;
            touchGainGold += upgrade;
            gameMoney -= 500 * touchUpgradeLevel;
            touchUpgradeLevel++;
            touchUpgradePrice = 500 * touchUpgradeLevel;
        }
        else
        {
            Debug.Log("골드가 부족합니다.");
        }
    }
    public static void SellUnit(GameObject prefab) //지피티의 산물
    {
        if (unitInstancesByType.ContainsKey(prefab) && unitInstancesByType[prefab].Count > 0)
        {
            GameObject unitToSell = unitInstancesByType[prefab][0]; // 가장 먼저 생성된 유닛
            unitInstancesByType[prefab].RemoveAt(0);
            spawndObject.Remove(unitToSell);
            GameObject.Destroy(unitToSell);
            Debug.Log("판매되었습니다.");
            currentUnits = spawndObject.Count;
        }
        else
        {
            Debug.Log("판매할 유닛이 없습니다.");
        }
        /*
        spawndObject.Remove(prefab) // 리스트 제거
        GameObject.Destroy(prefab) // 씬에서 오브젝트 제거
        currentUnits = spawndObject.Count // 유닛 수 동기화
        */
    }
}
