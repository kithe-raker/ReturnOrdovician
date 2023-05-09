using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;//for timer
using UnityEngine.UIElements;

namespace Unity.FPS.AI
{  
public class EnemyTermite : EnemyMobile
{
        

        private float attackTimer=0; //Timer that will start when it attack, stop at attack_delay time
        [SerializeField] float attack_delay=0.75f;// when mantis start causing damage after close enough
        public Animator FarexAnim;
        


        public override void UpdateCurrentAiState() 
        {
              if(AiState != AIState.Attack){
                attackTimer = 0;
            }
            switch (AiState)
            {
                case AIState.Patrol:
                    if(AttackStopDistanceRatio > 0.4f){AttackStopDistanceRatio = 0.2f;} //Yesno, Zen, ferrix stop too soon bug
                    m_EnemyController.UpdatePathDestination();
                    m_EnemyController.SetNavDestination(m_EnemyController.GetDestinationOnPath());
                    break;
                case AIState.Follow:
                    if(AttackStopDistanceRatio > 0.4f){AttackStopDistanceRatio = 0.2f;} //Yesno,Zen, ferrix stop too soon bug
                    m_EnemyController.SetNavDestination(m_EnemyController.KnownDetectedTarget.transform.position);
                    m_EnemyController.OrientTowards(m_EnemyController.KnownDetectedTarget.transform.position);
                    m_EnemyController.OrientWeaponsTowards(m_EnemyController.KnownDetectedTarget.transform.position);
                    break;
                case AIState.Attack:
                    if(AttackStopDistanceRatio > 0.4f){AttackStopDistanceRatio = 0.2f;}  //Yesno,Zen, ferrix stop too soon bug
                    attackTimer += Time.deltaTime;
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

                     if(attackTimer> attack_delay)
                    {
                        FarexAnim.SetBool("Attack", true);
                        m_EnemyController.OrientTowards(m_EnemyController.KnownDetectedTarget.transform.position);
                        m_EnemyController.TryAtack(m_EnemyController.KnownDetectedTarget.transform.position); 
                        //attackTimer = 0;
                    }

                    break;
            }
        }



        /*
         switch (AiState)
            {
                case AIState.Patrol:
                    m_EnemyController.UpdatePathDestination();
                    m_EnemyController.SetNavDestination(m_EnemyController.GetDestinationOnPath());
                    break;
                case AIState.Follow:
                    m_EnemyController.SetNavDestination(m_EnemyController.KnownDetectedTarget.transform.position);
                    m_EnemyController.OrientTowards(m_EnemyController.KnownDetectedTarget.transform.position);
                    m_EnemyController.OrientWeaponsTowards(m_EnemyController.KnownDetectedTarget.transform.position);
                    break;
                case AIState.Attack:
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

                    m_EnemyController.OrientTowards(m_EnemyController.KnownDetectedTarget.transform.position);
                    m_EnemyController.TryAtack(m_EnemyController.KnownDetectedTarget.transform.position);
                    break;
            }
        */



}
}