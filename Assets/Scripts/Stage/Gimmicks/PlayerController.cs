using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator; //ゲームスタート，クリア，ゲームオーバーアニメーションを持つ

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        // animator = GetComponent<Animator>();
    }

    public async UniTaskVoid PlayGameOverAction(Vector3 damageSourcePosition)
    {
        rb.linearVelocity = Vector2.zero;

        // 2. 跳ね返る方向を計算（ダメージ源の逆方向 ＋ 上方向を強調）
        Vector2 knockbackDir = (transform.position - damageSourcePosition).normalized;
        //knockbackDir.y = 1.2f; // 上方向に強く跳ねさせる補正

        // 3. 瞬間的な力（Impulse）を加えてノックバックさせる
        float knockbackPower = 1f;
        rb.AddForce(knockbackDir * knockbackPower, ForceMode2D.Impulse);

        float spinPower = 2f; // 回転の勢い
        float spinTorque = -Mathf.Sign(knockbackDir.x) * spinPower;
        rb.AddTorque(spinTorque, ForceMode2D.Impulse);

        // 4. 跳ねて飛んでいる時間（例: 0.4秒）だけ待機
        await UniTask.Delay(TimeSpan.FromSeconds(0.4f));

        rb.angularVelocity = 0f;
        rb.linearVelocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Kinematic;
    }
}
