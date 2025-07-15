using System.Collections;
using UnityEngine;

public class Homework_0715 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator TestExam_1_Routine()
    {
        // divide by zero
        // ºÐÀÚ´Â ¿Ö ±¦Âú°í ºÐ¸ð´Â ¿Ö ¾È ±¦Âú¾Æ?

        //

        // 2ºÐÀÇ 1 = 1/2
        // 1 * 1/2 = 1 / 2
        // x = 4 / y
        // x * y = 4 / y * y
        // x * y = 4

        // 0 / 4 = 0
        // 0 * (1 / 4) = 0
        // 0 * 10 = 0
        // 0 / 10 = ? = 0
        // 0 / x = ???
        // -> 0 * (1/x) = 0

        // 4 / 0 = ?
        // 4 * (1 / 0) 

        // Dividing by zero is undefined in standard arithmetic
        // because it leads to inconsistencies and contradictions within the mathematical system


        var currentTime = 0f;
        var maxTime = 25f;
        var clampValue = currentTime / maxTime;
        var iteration = 0;
        // FPS 60
        // 1 / 60 ? -> 0.0166667f
        // 2 / 60 ? // 0.0333333f
        while (clampValue < 1f)
        {
            currentTime += Time.deltaTime; // ->
            clampValue = currentTime / maxTime;
            Debug.Log("asdf " + iteration);
            iteration++;
            yield return null;
        }
        Debug.Log("test iteration end");
        
        // 0715 TODO, homemwork
        // 1. total time -> just answer it
        // 2. iteration count -> why? are those so many of them



    }

}
