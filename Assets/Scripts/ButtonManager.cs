using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject currentCard;
    public Vector3 setUpPos = Vector3.zero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetPosition()
    {
        if (currentCard == null)
        {
            return;
        }
        currentCard.transform.position = setUpPos;
    }
}
