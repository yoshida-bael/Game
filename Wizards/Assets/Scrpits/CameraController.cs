using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ネームスペースの設定
namespace FPS{
	public class CameraController : MonoBehaviour {

		[Range(0.1f, 10f)]
		public float lookSensitivity = 5f;
		[Range(0.1f, 1f)]
		public float lookSmooth = 0.1f;

		public Vector2 MinMaxAngle = new Vector2 (-65, 65);

		private float yRot;
		private float xRot;

		private float currentYRot;
		private float currentXRot;

		private float yRotVelocity;
		private float xRotVelocity;

		void Update () {
			yRot += Input.GetAxis ("Mouse X") * lookSensitivity;  // マウスの横移動
			xRot -= Input.GetAxis ("Mouse Y") * lookSensitivity;  // マウスの縦移動

			// （ポイント）「Clamp」の意味と使い方をネットで調べよう！
			xRot = Mathf.Clamp(xRot, MinMaxAngle.x, MinMaxAngle.y); // 上下の角度移動の最大、最小

			// （ポイント）「SmoothDamp」の意味と使い方をネットで調べよう！
			currentXRot = Mathf.SmoothDamp (currentXRot, xRot, ref xRotVelocity, lookSmooth);
			currentYRot = Mathf.SmoothDamp (currentYRot, yRot, ref yRotVelocity, lookSmooth);

			transform.rotation = Quaternion.Euler (currentXRot, currentYRot, 0);
		}
	}
}