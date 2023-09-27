//using System;

using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private StateMachine stateMachine;

    private NavMeshAgent agent;

    public NavMeshAgent Agent { get => agent; }

    [SerializeField]
    private string currentState;
    public Path path;

    //
    [Header("Sight")]
    private GameObject player;
    public float sightDistance = 45f;
    public float fieldOfView = 85f;

    [SerializeField] private float MaxHealth = 100f;
    [SerializeField] private Image healthBar;

    private float currentHealth;

    //Attack
    //[Header("Attack")]
    //   public float 

    // Start is called before the first frame update
    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        agent = GetComponent<NavMeshAgent>();
        stateMachine.Initialize();
        player = GameObject.FindWithTag("Player");

        currentHealth = MaxHealth;
    }

    public void ChangeHealth(float delta)
    {
        currentHealth += delta;

        if(healthBar) healthBar.fillAmount = currentHealth / MaxHealth;

        if(currentHealth <= 0f)
        {
            Destroy(gameObject);
		}
    }

    // Update is called once per frame
    void Update()
    {
        CanSeePlayer();
        currentState = stateMachine.activeState.ToString();
    }

    public bool CanSeePlayer()
    {
        if (player != null)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < sightDistance)
            {
                // calculate the angel and check if it is within the field of view
                Vector3 targetDirection = player.transform.position - transform.position;
                float angelToPlayer = Vector3.Angle(targetDirection, transform.forward);

                if (angelToPlayer >= -fieldOfView && angelToPlayer <= fieldOfView)
                {
                    Ray ray = new Ray(transform.position, targetDirection);
                    RaycastHit hitInfo = new RaycastHit();
                    if (Physics.Raycast(ray, out hitInfo, sightDistance))
                    {
                        if (hitInfo.transform.gameObject == player)
                        {
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
			//gameObject.GetComponent<Animation>().Play("Attack2");
			other.gameObject.GetComponent<PlayerHealthBar>().TakeDamage(Random.Range(7, 10));
        }
    }
    private void OnTriggerExit(Collider other)
    {
        gameObject.GetComponent<Animation>().Play("Walk");
    }
}
