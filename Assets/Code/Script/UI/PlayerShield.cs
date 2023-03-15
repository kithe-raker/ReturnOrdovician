using Unity.FPS.Game;
using Unity.FPS.Gameplay;
using UnityEngine;
using UnityEngine.UI;

namespace Unity.FPS.UI
{
    public class PlayerShield : MonoBehaviour
    {
        [Tooltip("Image component dispplaying current health")]
        public Image ShieldFillImage;

        Shield m_PlayerShield;

        void Start()
        {
            PlayerCharacterController playerCharacterController =
                GameObject.FindObjectOfType<PlayerCharacterController>();
            DebugUtility.HandleErrorIfNullFindObject<PlayerCharacterController, PlayerShield>(
                playerCharacterController, this);

            m_PlayerShield = playerCharacterController.GetComponent<Shield>();
            DebugUtility.HandleErrorIfNullGetComponent<Shield, PlayerShield>(m_PlayerShield, this,
                playerCharacterController.gameObject);
        }

        void Update()
        {
            // update health bar value
            ShieldFillImage.fillAmount = m_PlayerShield.CurrentShield / m_PlayerShield.MaxShield;
        }
    }
}