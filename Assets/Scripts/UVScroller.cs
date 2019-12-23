using UnityEngine;

public class UVScroller : MonoBehaviour {
		public Vector2 scrollSpeed = new Vector2(-1f, 0f);

		private GameManager gameManager;
		//public string textureName = "grid_256_thick";
		private Material target;
		public Vector2 offset = Vector2.zero;

		void Start () {
			gameManager = FindObjectOfType<GameManager>();

			var renderer = GetComponent<Renderer>();
			if (renderer == null || renderer.material == null) {
				this.enabled = false;
				return;
			}

			target = renderer.material;
			//if (!target.HasProperty(textureName)) {
			//	Debug.LogWarning("Texture name '" + textureName + "' not found in material.");
			//	this.enabled = false;
			//	return;
			//}
		}
		
		void Update () {
            //rb.MovePosition(transform.position - transform.forward * Time.fixedDeltaTime * -Application.targetFrameRate * gameManager.moveBackSpeed);

			scrollSpeed.y = (gameManager.moveBackSpeed * Time.fixedDeltaTime * Application.targetFrameRate) / gameManager.moveBackSpeed;

            offset = offset - ( scrollSpeed );
			//offset += scrollSpeed * Time.deltaTime * Application.targetFrameRate;
			//target.SetTextureOffset(textureName, offset);
            target.SetVector("Vector2_4ED846C9", offset); 
		}
	}