using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ネームスペース（名前空間）についてネットで調べてみよう！
namespace FPS
{

    // 列挙型の宣言
    // enum（イーナム）についてネットで調べてみよう！
    public enum PlayerState
    {
        Idle, Walking, Running, Jumping
    }

    // 属性（Attribute）についてネットで調べてみよう！
    // RequireComponentの使い方をネットで調べてみよう！
    // RequireComponentを使うことでどんな効果があるかを確認しましょう。
    [RequireComponent(typeof(CharacterController), typeof(AudioSource))]
    public class PlayerController : MonoBehaviour
    {

        // Rangeも属性です。これを使うとどんな効果があるのか確認しましょう。
        [Range(0.1f, 2f)]
        public float walkSpeed = 1.5f;
        [Range(0.1f, 10f)]
        public float runSpeed = 3.5f;

        // キャラクターコントローラー
        private CharacterController charaController;

        private GameObject FPSCamera;
        private Vector3 moveDir = Vector3.zero;

        [Range(0.1f, 10f)]
        public float gravity = 9.8f;  // 重力の大きさ
        [Range(1f, 15f)]
        public float jumpPower = 10f;  // ジャンプ力

        [Range(0.1f, 2f)]
        public float crouchHeight = 1f;  // しゃがんだ時の背の高さ
        [Range(0.1f, 5f)]
        public float normalHeight = 2f;  // 通常時の背の高さ

        [HideInInspector]  // この属性の意味と効果をネットで調べてみよう！
        public PlayerState currentPlayerState;
        [HideInInspector]
        public bool isWalking = false;
        [HideInInspector]
        public bool isRunning = false;
        [HideInInspector]
        public bool isCrouching = false;

        public AudioClip walkSound;
        public AudioClip runSound;
        private AudioSource footStepSource;
        [HideInInspector]
        public float footSoundDelay;

        void Start()
        {
            FPSCamera = GameObject.Find("FPSCamera");

            charaController = GetComponent<CharacterController>();
        }

        void Update()
        {
            Move();
            Crouch();
            PlayerStateManager();
            print(currentPlayerState);  // 現在のプレーヤーのステート（状態）を目で確認できるようにする。
        }

        void Move()
        {
            float moveH = Input.GetAxis("Horizontal");
            float moveV = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveH, 0, moveV);

            if (movement.sqrMagnitude > 1)
            {
                movement.Normalize();
            }

            Vector3 desiredMove = FPSCamera.transform.forward * movement.z + FPSCamera.transform.right * movement.x;
            moveDir.x = desiredMove.x * 5f;
            moveDir.z = desiredMove.z * 5f;

            // 歩行とランを切り替える。
            if (Input.GetKey(KeyCode.LeftShift))
            {
                charaController.Move(moveDir * Time.fixedDeltaTime * runSpeed);
                isWalking = false;
                isRunning = true;
            }
            else
            {
                charaController.Move(moveDir * Time.fixedDeltaTime * walkSpeed);
                isWalking = true;
                isRunning = false;
            }

            moveDir.y -= gravity * Time.deltaTime;  // 重力の発生
            if (charaController.isGrounded)
            { // この条件の意味を調べてみよう
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    moveDir.y = jumpPower; // ジャンプ
                }
            }
        }

        void Crouch()
        {
            if (Input.GetKey(KeyCode.LeftCommand))
            {
                charaController.height = crouchHeight;
                isCrouching = true;
            }
            else
            {
                charaController.height = normalHeight;
                isCrouching = false;
            }
        }

        // プレーヤーのステート（状態）管理
        void PlayerStateManager()
        {
            if (charaController.isGrounded)
            {
                if (charaController.velocity.sqrMagnitude < 0.01f)
                {
                    currentPlayerState = PlayerState.Idle;  // Idle状態

                }
                else if (isWalking == true && isRunning == false)
                {
                    currentPlayerState = PlayerState.Walking;  // Walking状態

                }
                else if (charaController.velocity.sqrMagnitude > 0.01f && isWalking == false && isRunning == true)
                {
                    currentPlayerState = PlayerState.Running;  // Running状態
                }
            }
            else
            {
                currentPlayerState = PlayerState.Jumping;
            }
        }

        public IEnumerator PlayerFootSound()
        { // 「IEnumerator」についてネットで調べてみよう！ 
            while (true)
            {
                if (currentPlayerState != PlayerState.Idle)
                {
                    if (currentPlayerState == PlayerState.Walking)
                    {
                        footStepSource.PlayOneShot(walkSound, 0.9f);
                        footStepSource.pitch = Random.Range(1f, 1.2f);
                        footSoundDelay = 1 / walkSpeed;
                    }

                    if (currentPlayerState == PlayerState.Running)
                    {
                        footStepSource.PlayOneShot(runSound, 0.9f);
                        footStepSource.pitch = Random.Range(1f, 1.2f);
                        footSoundDelay = 1 / runSpeed;
                    }
                }

                yield return new WaitForSeconds(footSoundDelay * 2);  // 「WaitForSeconds」について調べてみよう！
            }
        }

    }
}