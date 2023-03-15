using UnityEngine;
using UnityEngine.Events;

namespace Unity.FPS.Game
{
    public class Shield : MonoBehaviour
    {
        [Tooltip("Maximum amount of shield")] public float MaxShield = 10f;

        [Tooltip("Shield ratio at which the critical health vignette starts appearing")]
        public float CriticalShieldRatio = 0.0f;

        public UnityAction<float, GameObject> OnDamaged;
        public UnityAction<float> OnHealed;
        public UnityAction OnDie;

        public float CurrentShield { get; set; }
        public bool Invincible { get; set; }
        public bool CanPickup() => CurrentShield < MaxShield;

        public float GetRatio() => CurrentShield / MaxShield;
        public bool IsCritical() => GetRatio() <= CriticalShieldRatio;

        void Start()
        {
            CurrentShield = MaxShield;

        }

        public void TakeDamage(float damage, GameObject damageSource)
        {

            float shieldBefore = CurrentShield;
            CurrentShield -= damage;
            CurrentShield = Mathf.Clamp(CurrentShield, 0f, MaxShield);

            // call OnDamage action
            float trueDamageAmount = shieldBefore - CurrentShield;
        }

        public void Kill()
        {
            CurrentShield = 0f;

            // call OnDamage action
            OnDamaged?.Invoke(MaxShield, null);
        }

        public bool CheckShield()
        {
            if (CurrentShield <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}