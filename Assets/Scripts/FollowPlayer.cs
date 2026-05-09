using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;
    private EventTrigger eventTrigger;
    [SerializeField] float followSpeed;   
    [SerializeField] float stopDistance;

    void Start()
    {
        eventTrigger = gameObject.GetComponent<EventTrigger>();
    }
    void Update()
    {
        if (target == null) return;
        if (eventTrigger.isMissionStarted)
        {
            float distance = Vector2.Distance(transform.position, target.position);

            if (distance > stopDistance)
            {

                transform.position = Vector2.MoveTowards(transform.position, target.position, followSpeed * Time.deltaTime);
            }
            if (target.position.x < transform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }
}
