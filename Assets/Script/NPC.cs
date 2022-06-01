using UnityEngine;

public class NPC : MonoBehaviour
{
    private CircleCollider2D circleRange;
    private GameObject waitingIcon;

    [Header("Charactor Settings")]
    public string charactorName;
    public bool isTalkable;
    public Sprite[] expression;

    private void Start()
    {
        circleRange = transform.GetChild(0).gameObject.GetComponent<CircleCollider2D>();
        waitingIcon = transform.GetChild(1).gameObject.transform.GetChild(0).gameObject;
        if(isTalkable) waitingIcon.SetActive(true);
        else waitingIcon.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        waitingIcon.SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(!isTalkable) return;
        waitingIcon.SetActive(true);
    }

    public Sprite[] GetExpression()
    {
        return expression;
    }    
}
