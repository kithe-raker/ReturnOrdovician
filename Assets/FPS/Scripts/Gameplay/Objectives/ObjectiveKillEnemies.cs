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
        public int KillsToCompleteObjective = 5;

        [Tooltip("Start sending notification about remaining enemies when this amount of enemies is left")]
        public int NotificationEnemiesRemainingThreshold = 3;

        public int m_KillTotal;
        public int killedTest;

        

        //Number of enemies to spawn
        public int numEnemiesToSpawn = 1;

        //How many waves?
        public int Waves = 3;

        //list of spawn points
        public List<Transform> pointsLevel1;
        public List<Transform> pointsLevel2;
        public List<Transform> pointsLevel3;






        protected override void Start()
        {
            base.Start();

            EventManager.AddListener<EnemyKillEvent>(OnEnemyKilled);
            KillsToCompleteObjective = Waves * numEnemiesToSpawn * pointsLevel1.Count;

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
            killedTest++;

            if (MustKillAllEnemies)
                KillsToCompleteObjective = Waves*numEnemiesToSpawn*pointsLevel1.Count;

            int targetRemaining = MustKillAllEnemies ? evt.RemainingEnemyCount : KillsToCompleteObjective - m_KillTotal;

            // update the objective text according to how many enemies remain to kill
            if (targetRemaining == 0)
            {
                CompleteObjective(string.Empty, GetUpdatedCounterAmount(), "Objective complete : " + Title);
            }
            else if (/*targetRemaining == 1*/m_KillTotal == Waves * numEnemiesToSpawn * pointsLevel1.Count)
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