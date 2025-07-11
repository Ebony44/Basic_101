using System.Collections;
using UnityEngine;

public class CardMovingScript : MonoBehaviour
{
    public float someVariableFloat;
    private int someVariableInt;

    public GameObject currentCard = null;
    public BoxCollider boxCollider;
    public Vector3 targetVector = Vector3.zero;
    public Transform targetTrans = null;

    public float distanceVector = 0.1f;


    public void MoveCard()
    {
        // .hpp, .h
        // STL
        // 
    }

    public void MoveCard2()
    {
        MoveCard();
    }

    private void Awake()
    {
        Debug.Log("I'm called by awake method");

        StartCoroutine(TestRoutine(4f)); // -> StartCoroutine must be needed
        // TestRoutine(4f); // -> no execution

    }
    private void OnEnable()
    {
        Debug.Log("I'm called by on enable method");
    }



    // Coroutine: 코루틴은 Update와는 다르게 프레임 단위로 실행되지 않고, 특정 시간 간격으로 실행되는 함수입니다.
    public IEnumerator MoveRoutine()
    {
        // thread -> 
        // single ->

        // thread ? -> 어떻게 여러 개가 돌아가느냐? -> 여러개로 안 돌아감...
        // 일단 순차적이긴 함..
        
        // co -> 
        // company
        // companion
        // co + routine
        // routine? 정형화된 과정? 

        // 1. 평평하게 바닥에 앉아있음
        // 2. 카드를 띄운 후 로테이션,
        // 3. z 방향으로 일정이상 전진?
        // 4. 돌아오면서 로테이션도 앉아있는 상태로
        // 5. 1번 상태

        var originPos = currentCard.transform.position;


        yield return null;
    }

    // what is IEnumerator
    // // IEnumerator: C#에서 반복 가능한 객체를 나타내는 인터페이스로, 주로 코루틴에서 사용됩니다.
    public IEnumerator TestRoutine(float visualEffectTime = 2f)
    {
        float currentTime = 0;
        float maxTime = visualEffectTime;
        Debug.Log($"TestRoutine started, maxTime is {maxTime} seconds.");
        // 1. 매 0.5초마다 로그 출력
        // 2. 매 0.5초마다 x와 z 좌표를 랜덤하게 이동
        // 3. 매개변수 시간(visualEffectTime)만큼의 시간이 지나면 종료

        // 2.ex 만약 0.25초마다 x와 z 좌표로 하려면? -> 나랑 같이 해요

        // TODO: 95번째 줄, 0.5초 기다리는 걸 10초로 바꾸면 어떤 일이 일어날까?
        // TODO 2: 0.5초마다가 아니라 1초마다 로그가 찍히고, 좌표가 랜덤하게 움직이도록 하고 싶으면?

        int iterationCount = 0;
        while (currentTime < maxTime)
        {
            // currentTime += 0.5f * Time.deltaTime;
            currentTime += 0.5f; // 0.5초마다 실행되도록 설정
            // 1.
            Debug.Log($" log displayed, current Count: {iterationCount} "
                 + " current time is " + currentTime);
            iterationCount++;
            yield return new WaitForSeconds(0.5f);
            // yield return new WaitForEndOfFrame();
            // frame -> 

            var randomX = Random.Range(-1f * 0.4f, 1f * 0.4f);
            var randomZ = Random.Range(-1f * 0.4f, 1f * 0.4f);
            var currentPos = currentCard.transform.position;
            currentCard.transform.position += new Vector3(randomX, 0, randomZ);
            // yield return new WaitForSeconds(0.25f);

            // yield return new WaitForSeconds(0.5f);

            // yield return new WaitForEndOfFrame();
        }
        Debug.Log(" routine done.");
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("I'm called by start method");
        if(currentCard != null)
        {
            Debug.Log("asdf name is " + currentCard.name);
        }
        
        Debug.Log("if, game is on runtime and object is newly created? name is " + gameObject.name);

        // GetComponent<GameObject>();
        var tempCollider = GetComponent<BoxCollider>();

        
    }

    // Update is called once per frame
    // -> game loop, logic..?
    // 1 second 120 -> 
    // game logic...
    // ori -> jump interact
    void Update()
    {
        // fps 60 
        // fps? 60 120
        // per second 
        // currentCard.transform.position

        // call by value
        // call by reference

        return; // temp return, no need to update

        if (currentCard != null)
        {
            // currentCard.transform.position += new Vector3(2.0f * Time.deltaTime, 0, 0);

            // TODO: please move currentCard to (4,-3) position
            // using Vector3.MoveTowards
            //
            // Vector3.MoveTowards() : 사용해도 됨

            // (0,0) x->>>>>>>>>>>>>>>>>>
            // (0,0) , (4,-3)

            // 1. move logic

            // currentCard.transfrom.position += targetVector;

            // 2. when reached, stop moving

            if (Vector3.Distance(currentCard.transform.position, targetVector) > 0.01f)
            {
                // currentCard.transform.position += targetVector * distanceVector * Time.deltaTime;
                

                // TODO: 멈추게 해
                // 1. Vector3 MoveTowards
                // 2. get direction of vector -> (0, 0) : 이동 방향과 거리 구하기

                // (0, 0, 0) -> (4, 0, 0) -> 유클리드 거리: 4
                // (0, 0, 0) -> (4, -3, 0) -> 유클리드 거리: sqrt(73) = 8.54
                float moveSpeed = 5f;
                // currentCard.transform.position = Vector3.MoveTowards(currentCard.transform.position, targetVector, moveSpeed * Time.deltaTime);
                if(targetTrans != null)
                {
                    currentCard.transform.position = Vector3.MoveTowards(currentCard.transform.position, targetTrans.position, moveSpeed * Time.deltaTime);
                }

                // currentCard.transform.position: 현재 카드 오브젝트 위치
                // targetVector: 목표 위치
                // moveSpeed * Time.deltaTime: 이번 프레임에 최대 얼마만큼 이동할 수 있는가
            }
            float tempTestDistance = Vector3.Distance(Vector3.zero, new Vector3(5, 2, 0));
            Debug.Log("tempTestdistance is " + tempTestDistance);

            // x 5, y 3 
            // x -a, y -b 
            // 

            // if(Vector3.Distance())
            // x^2 + y^2 = z^2
            // 29 = z^2
            // z = sqrt(29)

            // currentCard.transform.position.x += 2.0f * Time.deltaTime;
        }

        if (someVariableFloat < 5f)
        {
            someVariableFloat += Time.deltaTime;
            Debug.Log("delta time is " + Time.deltaTime);
        }

        // graphic card.. fps 120
        // monitor fps 60
        // vsync 60 

        // vsync 
        // fps 120
        // 120 per sec
        // 1 frame -> 2 frame
        // fps 60
        // 1 / 60 = 0.0166667
        // 2 / 60 = 0.0333333

        // fps 120 
        // 1 / 120 = 0.0083333
        // 2 / 120 = 0.0166667
        // fps 120
        // after 0.5
        // fps 60
        // 0.5 
        // 60 / 120 -> 30 / 60
        // 
        
    }


    // Unity -> logic

    // -> after 1 frame
    // CardMovingScript -> object A -> Update()
    // CardMovingScript -> object B -> Update()
    // C,D,E, ... -> 
    // 10000 -> update?
    // 1 -> 10k 
    // 1 -> for 10000 ->


}
