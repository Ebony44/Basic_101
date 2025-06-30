using UnityEngine;

public class CardMovingScript : MonoBehaviour
{
    public float someVariableFloat;
    private int someVariableInt;

    public GameObject currentCard = null;
    public BoxCollider boxCollider;
    public Vector3 targetVector = Vector3.zero;

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
    }
    private void OnEnable()
    {
        Debug.Log("I'm called by on enable method");
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
                // TODO: 멈추게 해
                // 1. Vector3 MoveTowards
                // 2. get direction of vector -> (0, 0) : 이동 방향과 거리 구하기
                currentCard.transform.position += targetVector * distanceVector * Time.deltaTime;
            }
                float tempTestDistance = Vector3.Distance(Vector3.zero, new Vector3(5, 2, 0));
                Debug.Log("tempTestdistance is " + tempTestDistance);

            // if(Vector3.Distance())
            // x^2 + y^2 = z^2
            // 29 = z^2
            // z = sqrt(29)

            // currentCard.transform.position.x += 2.0f * Time.deltaTime;
        }

        someVariableFloat += Time.deltaTime;

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

        Debug.Log("delta time is " + Time.deltaTime);
    }
}
