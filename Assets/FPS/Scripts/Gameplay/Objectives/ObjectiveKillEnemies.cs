using Unity.FPS.Game;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Unity.FPS.Gameplay
{

    public class ObjectiveKillEnemies : Objective
    {
        [Tooltip("Chose whether you need to kill every enemies or only a minimum amount")]
        public bool MustKillAllEnemies = true;

        [Tooltip("If MustKillAllEnemies is false, this is the amount of enemy kills required")]
        public int KillsToCompleteObjective = 150;

        [Tooltip("Start sending notification about remaining enemies when this amount of enemies is left")]
        public int NotificationEnemiesRemainingThreshold = 3;

        public int m_KillTotal;
        public int killedTriggerMantis;
        public int killedTriggerFarex;
        public int killedTriggerWasp;

        public bool buttonPressed = false;









        //Level
        public int level = 1;
        public int change2 = 30;
        public int change3 = 80;

        //public int enemiesKillTest = 10;





        protected override void Start()
        {
            base.Start();

            EventManager.AddListener<EnemyKillEvent>(OnEnemyKilled);
           

            // set a title and description specific for this type of objective, if it hasn't one
            if (string.IsNullOrEmpty(Title))
                Title = "Eliminate " + (MustKillAllEnemies ? "all the" : KillsToCompleteObjective.ToString()) +
                        " enemies";

            if (string.IsNullOrEmpty(Description))
                Description = GetUpdatedCounterAmount();
        }

        void OnEnemyKilled(EnemyKillEvent evt)
        {
            if (IsCompleted)
                return;

            m_KillTotal++;
            killedTriggerMantis++;
            killedTriggerFarex++;
            killedTriggerWasp++;


            if (MustKillAllEnemies)
                KillsToCompleteObjective = 150;

            int targetRemaining = MustKillAllEnemies ? evt.RemainingEnemyCount : KillsToCompleteObjective - m_KillTotal;

            // update the objective text according to how many enemies remain to kill
            if (/*targetRemaining == 0*/m_KillTotal == KillsToCompleteObjective&&buttonPressed)
            {
                CompleteObjective(string.Empty, GetUpdatedCounterAmount(), "Objective complete : " + Title);
            }
            else if (/*targetRemaining == 1*/m_KillTotal == 149)
            {
                string notificationText = NotificationEnemiesRemainingThreshold >= targetRemaining
                    ? "One enemy left"
                    : string.Empty;
                //UpdateObjective(string.Empty, GetUpdatedCounterAmount(), notificationText);
            }
            /*else
            {
                // create a notification text if needed, if it stays empty, the notification will not be created
                string notificationText = NotificationEnemiesRemainingThreshold >= targetRemaining
                    ? targetRemaining + " enemies to kill left"
                    : string.Empty;

                UpdateObjective(string.Empty, GetUpdatedCounterAmount(), notificationText);
            }
            */

            if (m_KillTotal >= change2 && level == 1)
            {
                // Broadcast on level completed
                LevelCompletedEvent levelCompletedEvt = Events.LevelCompletedEvent;
                levelCompletedEvt.completedLevel = level;
                EventManager.Broadcast(levelCompletedEvt);

                level = 2;
                Debug.Log("Changed to level 2!");
            }
            else if (m_KillTotal >= change3 && level == 2)
            {
                // Broadcast on level completed
                LevelCompletedEvent levelCompletedEvt = Events.LevelCompletedEvent;
                levelCompletedEvt.completedLevel = level;
                EventManager.Broadcast(levelCompletedEvt);

                level = 3;
                Debug.Log("Changed to level 3!");
            }
        }

        string GetUpdatedCounterAmount()
        {
            return m_KillTotal + " / " + KillsToCompleteObjective;
        }

        void OnDestroy()
        {
            EventManager.RemoveListener<EnemyKillEvent>(OnEnemyKilled);
        }
    }
}