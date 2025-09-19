using System.Collections;
using UnityEngine;

public class UnitScript : MonoBehaviour
{
    Vector2 objectPosition;
    public int UnitgainGold;
    public int UnitPrice;
    float moveSpeed;

    void Start()
    {
        StartCoroutine("randomMove");
        StopCoroutine("CreatMoneyTime");
        StartCoroutine("CreatMoneyTime");
        GameManager.TotalGainGold += UnitgainGold;
    }
    void Update()
    {
        transform.position =
        Vector2.MoveTowards(transform.position, objectPosition, moveSpeed * Time.deltaTime);
    }
    void OnDestroy()
    {
        
    }

    IEnumerator randomMove()
    {
        while (true)
        {
            float randomX = Random.Range(-2.3f, +2.3f);
            float randomY = Random.Range(-4.7f, 3.3f);
            objectPosition = new Vector2(randomX, randomY);

            moveSpeed = Random.Range(1f, 3f);
            float randomTime = Random.Range(1f, 7f);
            yield return new WaitForSeconds(randomTime);
        }
    }
}