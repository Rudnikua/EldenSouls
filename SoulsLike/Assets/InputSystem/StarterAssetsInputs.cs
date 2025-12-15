using System;
using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;
		public bool draw;
		public bool attack;
		public bool heal;

		// добавлено
		public bool dodgeRoll;

        [Header("Movement Settings")]
		public bool analogMovement;

		public GameObject pausePanel; 
private bool isPaused = false;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

#if ENABLE_INPUT_SYSTEM

		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

        public void OnDraw(InputValue value)
        {
            DrawInput(value.isPressed);
        }

        public void OnAttack(InputValue value)
        {
            AttackInput(value.isPressed);
        }

        public void OnHeal(InputValue value) {
            HealInput(value.isPressed);
        }

        public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}

        public void OnDodgeRoll(InputValue value)
        {
            DodgeRollInput(value.isPressed);
        }

		public void OnPause(InputValue value)
		{
   		 if (value.isPressed)
   		 {
       		 Debug.Log("Escape нажата!");
       		 if (isPaused)
          	  ResumeGame();
        	else
           	 PauseGame();
   		 }
		}	

		public void PauseGame()
		{
    	if (pausePanel != null)
        	pausePanel.SetActive(true);

    	isPaused = true;	

    	Cursor.lockState = CursorLockMode.None;
    	Cursor.visible = true;

		}

		public void ResumeGame()
		{
    	if (pausePanel != null)
   		{
    		pausePanel.SetActive(false); // скрываем панель
        	Debug.Log("Панель паузы скрыта"); // проверка
    	}
    	else
    	{
        	Debug.LogWarning("pausePanel не подключена!");
    	}

    	isPaused = false;

    // Скрываем курсор
    	Cursor.lockState = CursorLockMode.Locked;
    	Cursor.visible = false;
		}	

#endif

		public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		}

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

        public void DrawInput(bool newDrawState)
        {
            draw = newDrawState;
        }

        public void AttackInput(bool newAttackState)
        {
            attack = newAttackState;
        }
        public void HealInput(bool newHealState) {
            heal = newHealState;
        }

        public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}

        // <<< добавлено
        public void DodgeRollInput(bool newRollState)
        {
            dodgeRoll = newRollState;
        }

        private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}
	}
}
