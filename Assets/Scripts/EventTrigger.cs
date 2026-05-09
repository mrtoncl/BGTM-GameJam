using UnityEngine;

public class EventTrigger : MonoBehaviour
{
    [SerializeField] GameObject cat;
    private CatInteraction catInteraction;
    public bool isMissionStarted = false;
    void Start()
    {
        catInteraction = cat.GetComponent<CatInteraction>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartEvent();
        }
        
    }

    void StartEvent()
    {
        if (catInteraction.didMeow && !isMissionStarted)
        {
            Debug.Log("It is started");
            isMissionStarted = true;
            catInteraction.didMeow = false;
        }
    }
}
