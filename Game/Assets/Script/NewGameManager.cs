using TMPro;
using System.Collections.Generic;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    List<GameObject> spawndObject = new List<GameObject>();
    public static int maxunits = 10;
    public static int currentUnits;

    void Awake()
    {
        
    }
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        
    }
    void Update()
    {
        
    }
}
public class Money
{
    int MyMoney;

}
public class UnitSpawn : MonoBehaviour
{
    List<GameObject> spawndObject = new List<GameObject>();
    public static int maxunits = 10;
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
public class UnitMax
{

}
public class Ui
{
    public TextMeshPro Gold;
    public TextMeshPro Unit;
    //UI 슬롯 생성
    void Update()
    {
        GoldUi();
        UnitUi();
    }
    void GoldUi()
    {
        Gold.text = "골드 : " + UnitScript.gameMoney + "G";
    }
    void UnitUi()
    {
        Unit.text = "유닛 수 : " + GameManager.currentUnits + "/" + GameManager.maxunits;
    }
}