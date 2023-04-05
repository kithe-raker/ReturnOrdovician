using UnityEngine;
using UnityEngine.Events;
using System.Collections;
namespace Unity.FPS.Game
{
    public class Health : MonoBehaviour
    {

        [Tooltip("Maximum amount of health")] public float MaxHealth = 100f;
        [Tooltip("Maximum amount of health")] public float MaxShield = 100f;
        [Tooltip("Health ratio at which the critical health vignette starts appearing")]
        public float CriticalHealthRatio = 0.3f;

        public UnityAction<float, GameObject> OnDamaged;
        public UnityAction<float> OnHealed;
        public UnityAction OnDie;
        
        public float CurrentHealth { get; set; }
        public float CurrentShield { get; set; }
        public bool Invincible { get; set; }
        public bool CanPickup() => CurrentHealth < MaxHealth;

        public float GetRatio() => CurrentHealth / MaxHealth;
        public bool IsCritical() => GetRatio() <= CriticalHealthRatio;
        public float RegenAmount = 5.0f;

        public int ShieldRegenRate = 5;

        private bool regenShield = false;

        private Coroutine shiledRegenCour;

        bool m_IsDead;
        
        void Start()
        {
            CurrentHealth = MaxHealth;
            CurrentShield = MaxShield;
        }
        private void Update()
        {
            bool doRegen = (CurrentShield < MaxShield) && !regenShield;
            if (doRegen)
            {
                shiledRegenCour = StartCoroutine(RegenerateShield());
            }
        }

        public void Heal(float healAmount)
        {
            float healthBefore = CurrentHealth;
            CurrentHealth += healAmount;
            CurrentHealth = Mathf.Clamp(CurrentHealth, 0f, MaxHealth);

            // call OnHeal action
            float trueHealAmount = CurrentHealth - healthBefore;
            if (trueHealAmount > 0f)
            {
                OnHealed?.Invoke(trueHealAmount);
            }
        }

        public void TakeDamage(float damage, GameObject damageSource)
        {
            if (Invincible)
                return;
            if (CurrentShield > 0)
            {
                float ShieldBefore = CurrentShield;
                CurrentShield -= damage;
                CurrentShield = Mathf.Clamp(CurrentShield, 0f, MaxShield);

                // call OnDamage action
                float trueDamageAmountS = ShieldBefore - CurrentShield;
                if (trueDamageAmountS > 0f)
                {
                    OnDamaged?.Invoke(trueDamageAmountS, damageSource);
                }
                return;
            }
            float healthBefore = CurrentHealth;
            CurrentHealth -= damage;
            CurrentHealth = Mathf.Clamp(CurrentHealth, 0f, MaxHealth);

            // call OnDamage action
            float trueDamageAmount = healthBefore - CurrentHealth;
            if (trueDamageAmount > 0f)
            {
                OnDamaged?.Invoke(trueDamageAmount, damageSource);
            }

            HandleDeath();
        }

        public void Kill()
        {
            CurrentHealth = 0f;

            // call OnDamage action
            OnDamaged?.Invoke(MaxHealth, null);

            HandleDeath();
        }

        void HandleDeath()
        {
            if (m_IsDead)
                return;

            // call OnDie action
            if (CurrentHealth <= 0f)
            {
                m_IsDead = true;
                OnDie?.Invoke();
            }
        }

        
        private IEnumerator RegenerateShield()
        {
            Debug.Log($"Start Regen");

            regenShield = true;

            yield return new WaitForSeconds(ShieldRegenRate);

            while (((float)CurrentShield < (int)MaxShield) && regenShield)
            {
                CurrentShield += RegenAmount;
                if (CurrentShield == MaxShield/2)
                {
                    regenShield = false;
                    break;
                }
                yield return new WaitForSeconds(1.0f);
            }
            Debug.Log("regen false");
        }
    }
}