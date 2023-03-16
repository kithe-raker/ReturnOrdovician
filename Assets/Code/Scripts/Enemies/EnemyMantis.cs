using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;//for timer
namespace Unity.FPS.AI
{  
public class EnemyMantis : EnemyMobile
{
        public Animator AnimSB02;
        public bool left = true;
        private float attackTimer=0; //Timer that will start when it attack, stop at attack_delay time
        private float standStillTimer=0; //Timer that will start when it attack, stop at stand_still_delay time
        private bool startStandStillTimer = false; //will start standStillTimer when it true, stop standStillTimer when it false
        [SerializeField] float attack_delay=0.75f;// when mantis start causing damage after close enough
        [SerializeField] float stand_still_delay=2f;// how long mantis will stand still after close enough
        [SerializeField] float mantis_speed=5f;//mantis walking speed
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
                    AnimSB02.SetBool("Stop", true);
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
                        if (left == true)
                        {
                            AnimSB02.SetBool("Left", false);
                            left= false;
                        }
                        else
                        {
                            AnimSB02.SetBool("Left", true);
                            left= true;
                        }
                    }
                    
                    break;
            }
        }

}
}