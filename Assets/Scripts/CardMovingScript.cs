using UnityEngine;

public class CardMovingScript : MonoBehaviour
{
    public float someVariableFloat;
    private int someVariableInt;

    public GameObject currentCard = null;
    public BoxCollider boxCollider;


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
            currentCard.transform.position += new Vector3(2.0f * Time.deltaTime, 0, 0);
            // move to 4,-3
            if (currentCard.transform.position.x > 4.0f)
            {
                currentCard.transform.position = new Vector3(4.0f, -3.0f, 0.0f);
            }
            // TODO: please move currentCard to (4,-3) position
            //

            // (0,0) x->>>>>>>>>>>>>>>>>>
            // (0,0) , (4,-3)

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
