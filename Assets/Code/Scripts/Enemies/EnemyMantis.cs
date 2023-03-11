using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;//for timer
namespace Unity.FPS.AI
{  
public class EnemyMantis : EnemyMobile
{

    private float attackTimer=0; 
    private float standStillTimer=0; 
    private bool startStandStillTimer = false; 
    [SerializeField] float attack_delay=0.75f;
    [SerializeField] float stand_still_delay=2f;
    [SerializeField] float mantis_speed=5f;
    public override void UpdateCurrentAiState() 
        {
            if(startStandStillTimer==true)
            {
                standStillTimer += Time.deltaTime;
                 m_EnemyController.NavMeshAgent.speed = 0;
                 if(standStillTimer>stand_still_delay){
                    standStillTimer = 0;
                    startStandStillTimer=false;
                 }
            }
            void stopStandStillFunc(){
                if(startStandStillTimer==false)
                {
                    m_EnemyController.NavMeshAgent.speed = mantis_speed;
                }
            }
            switch (AiState)
            {
                
                case AIState.Patrol:
                    stopStandStillFunc();
                    attackTimer = 0;
                    m_EnemyController.UpdatePathDestination();
                    m_EnemyController.SetNavDestination(m_EnemyController.GetDestinationOnPath());
                    break;
                case AIState.Follow:
                    stopStandStillFunc();
                    attackTimer = 0;
                    m_EnemyController.SetNavDestination(m_EnemyController.KnownDetectedTarget.transform.position);
                    m_EnemyController.OrientTowards(m_EnemyController.KnownDetectedTarget.transform.position);
                    m_EnemyController.OrientWeaponsTowards(m_EnemyController.KnownDetectedTarget.transform.position);
                    break;
                case AIState.Attack:
                    attackTimer += Time.deltaTime;
                    startStandStillTimer=true;
                    if (Vector3.Distance(m_EnemyController.KnownDetectedTarget.transform.position,
                            m_EnemyController.DetectionModule.DetectionSourcePoint.position)
                        >= (AttackStopDistanceRatio * m_EnemyController.DetectionModule.AttackRange))
                    {
                        m_EnemyController.SetNavDestination(m_EnemyController.KnownDetectedTarget.transform.position);
                    }
                    else
                    {
                        m_EnemyController.SetNavDestination(transform.position);
                    }
                    if(attackTimer> attack_delay){
                    m_EnemyController.OrientTowards(m_EnemyController.KnownDetectedTarget.transform.position);
                    m_EnemyController.TryAtack(m_EnemyController.KnownDetectedTarget.transform.position);
                    attackTimer = 0;
                    }
                    break;
            }
        }

}
}