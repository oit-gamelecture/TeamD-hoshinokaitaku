using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astronaut3 : MonoBehaviour
{
    public Vector3[] jumpTargets = new Vector3[] {
        new Vector3(-51f, 3.75f, 14.12f),
        new Vector3(-36f, 3.75f, 50.37f),
        new Vector3(-4.1f, 3.75f, 73.57f),
        new Vector3(32.52f, 3.75f, 46.68f),
        new Vector3(58.1f, 3.75f, 15.67f),
        new Vector3(64.8f, 3.75f, -25.38f),
        new Vector3(54.75f, 3.75f, -65.1f),
        new Vector3(33.49f, 3.75f, -91.67f),
        new Vector3(-1.68f, 3.75f, -109.64f),
        new Vector3(-36.89f, 3.75f, -84.34f),
        new Vector3(-54.4f, 3.75f, -51.65f),
        new Vector3(-58.31f, 3.75f, -20.5f)
    }; // 跳躍する目標位置

    public float jumpHeight = 12.0f; // 跳躍の高さ
    public float jumpDuration = 1.0f; // 跳躍の持続時間

    private Rigidbody rb;
    private bool isJumping = false;
    private float jumpStartTime;
    private Vector3 jumpStartPosition;
    private Vector3 jumpTargetPosition;
    private int currentTargetIndex = 0; // 現在の目標位置のインデックス

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            StartJump();
        }

        if (isJumping)
        {
            float jumpProgress = (Time.time - jumpStartTime) / jumpDuration;
            if (jumpProgress <= 1.0f)
            {
                // ジャンプ中の位置を計算
                Vector3 jumpPosition = Vector3.Lerp(jumpStartPosition, jumpTargetPosition, jumpProgress);
                jumpPosition.y += Mathf.Sin(jumpProgress * Mathf.PI) * jumpHeight; // 高さの調整
                rb.MovePosition(jumpPosition);
            }
            else
            {
                // ジャンプ終了
                isJumping = false;
                currentTargetIndex = (currentTargetIndex + 1) % jumpTargets.Length; // 次の目標位置に移動
            }
        }
    }

    void StartJump()
    {
        // ジャンプ開始時の情報を保存
        isJumping = true;
        jumpStartTime = Time.time;
        jumpStartPosition = rb.position;
        jumpTargetPosition = jumpTargets[currentTargetIndex];

        // ジャンプの初速度を計算
        rb.velocity = CalculateJumpVelocity(jumpStartPosition, jumpTargetPosition);
    }

    Vector3 CalculateJumpVelocity(Vector3 start, Vector3 target)
    {
        Vector3 displacement = target - start;
        float time = Mathf.Sqrt(-2 * jumpHeight / Physics.gravity.y) + Mathf.Sqrt(2 * (displacement.y - jumpHeight) / Physics.gravity.y);
        Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * Physics.gravity.y * jumpHeight);
        Vector3 velocityXZ = new Vector3(displacement.x / time, 0, displacement.z / time);
        return velocityXZ + velocityY;
    }
}
