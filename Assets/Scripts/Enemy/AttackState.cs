
using UnityEngine;

public class AttackState : BaseState
{
    private float moveTimer;
    private float losePlayerTimer;

    public GameObject player = GameObject.FindWithTag("Player");
	public override void Enter(){ }

	public override void Exit(){ }

	public override void Perform()
    {
        if (enemy.CanSeePlayer())
        {
            //losePlayerTimer = 0;
            //moveTimer += Time.deltaTime;
            //if (moveTimer > Random.Range(3, 7))
            //{
                //enemy.Agent.SetDestination(enemy.transform.powsition + (Random.insideUnitSphere * 5));
                enemy.Agent.ResetPath();
                enemy.Agent.SetDestination(player.transform.position);
			    enemy.GetComponent<Animation>().Play("Attack2");
			    enemy.Agent.speed = 8;
                moveTimer = 0;
            //}
        }
        else
        {
			//losePlayerTimer += Time.deltaTime;
			//if (losePlayerTimer > 8)
			//{
			    enemy.GetComponent<Animation>().Play("Walk");
			    enemy.Agent.speed = 3;
			    stateMachine.ChangeState(new PatrolState());
            //}
        }
    }

}
