using Unity.Android.Gradle.Manifest;
using UnityEngine;

public class UnitScript : MonoBehaviour
{
    Vector2 unitMove = new Vector2(0, 0);


    void FixedUpdate()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        transform.position =
        Vector2.MoveTowards(transform.position, unitMove, 2f * Time.deltaTime);
        
    }
}
