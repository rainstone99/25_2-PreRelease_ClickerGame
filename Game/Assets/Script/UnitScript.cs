using System.Collections;
using Unity.Android.Gradle.Manifest;
using UnityEngine;

public class UnitScript : MonoBehaviour
{
    Vector2 objectPosition;

    void Start()
    {
        StartCoroutine("randomMove");
    }
    void FixedUpdate()
    {

    }
    // Update is called once per frame
    void Update()
    {
        transform.position =
        Vector2.MoveTowards(transform.position, objectPosition, 2f * Time.deltaTime);

    }
    IEnumerator randomMove()
    {
        while (true)
        {
            float randomX = Random.Range(-2.3f, +2.3f);
            float randomY = Random.Range(-4.7f, 3.3f);
            objectPosition = new Vector2(randomX, randomY);

            float randomTime = Random.Range(1f, 7f);
            yield return new WaitForSeconds(randomTime);       
        }
    }
}
