using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class ThirdPersonUserControl : MonoBehaviour
    {
        private ThirdPersonCharacter m_Character; // 第三人称控制
        private Transform m_Cam;                  //摄像机的位置
        private Vector3 m_CamForward;             // 摄像机距离
        private Vector3 m_Move;
        private bool m_Jump;                     

        
        private void Start()
        {
         //摄像机的移动距离
            if (Camera.main != null)
            {
                m_Cam = Camera.main.transform;
            }
            else
            {
                Debug.LogWarning(
                    "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject);
                // 没有主相机
            }

      
            m_Character = GetComponent<ThirdPersonCharacter>();
        }


        private void Update()
        {
            if (!m_Jump)
            {
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
        }


        //物理状态更新
        private void FixedUpdate()
        {
            // 读取输入的数据
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
            bool crouch = Input.GetKey(KeyCode.C);

            // 移动距离
            if (m_Cam != null)
            {
                // 相机距离
                m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
                m_Move = v*m_CamForward + h*m_Cam.right;
            }
            else
            {
                // 摄像机的相对位置
                m_Move = v*Vector3.forward + h*Vector3.right;
            }
#if !MOBILE_INPUT
			// 走得最大速度
	        if (Input.GetKey(KeyCode.LeftShift)) m_Move *= 0.5f;
#endif

            
            m_Character.Move(m_Move, crouch, m_Jump);
            m_Jump = false;
        }
    }
}
