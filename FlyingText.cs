using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class FlyingText : MonoBehaviour {
	// attributes
	public float speed = 0.0f;
	public float duration = 20f;
	public float alpha = 1f;
	public bool bTextMesh = false;
	// this will create a UI text game object in the passed canvas transform
	// parameters: pos - it should be a world space position value
	// parentTransform - it should be a canvas game object's transform
	public static FlyingText getInstance(string text, Vector3 pos, int fontSize, Color color, float speed, float duration, Transform parentTransform) {
		// create game object
		GameObject obj = new GameObject ("Flying Text");
		obj.transform.parent = parentTransform;
		obj.transform.position = Camera.main.WorldToScreenPoint (pos);
		obj.transform.localScale = new Vector3 (1, 1, 1);
		// add text component
		Text t = obj.AddComponent<Text> ();
		t.text = text;
		t.alignment = TextAnchor.MiddleCenter;
		t.font = Font.CreateDynamicFontFromOSFont ("Arial", 20);
		//t.font = Resources.Load ("Fonts/slkscr") as Font; // use custom font
		t.fontSize = fontSize;
		t.color = color;
		// change rect transform value
		RectTransform rt = obj.GetComponent<RectTransform> ();
		rt.sizeDelta = new Vector2 (200, 40);
		// add script component
		FlyingText ft = obj.AddComponent<FlyingText> ();
		ft.bTextMesh = false;
		ft.speed = speed;
		ft.duration = duration;
		return ft;
	}
	// this will create a TextMesh game object in the passed parent transform
	public static FlyingText getInstanceWithTextMesh(string text, Vector3 pos, int fontSize, Color color, float speed, float duration, Transform parentTransform) {
		pos.z = parentTransform.position.z;
		// create game object
		GameObject obj = new GameObject ("Flying Text");
		obj.transform.parent = parentTransform;
		obj.transform.position = pos;
		obj.transform.localScale = new Vector3 (1, 1, 1);
		// add text component
		TextMesh t = obj.AddComponent<TextMesh> ();
		t.text = text;
		t.alignment = TextAlignment.Left;
		t.font = Font.CreateDynamicFontFromOSFont ("Arial", 20);
		// t.font = Resources.Load ("Fonts/slkscr") as Font;
		t.fontSize = fontSize;
		t.color = color;
		t.characterSize = 0.1f;
		// assign renderer material
		Renderer r = obj.GetComponent<Renderer> ();
		r.sharedMaterial = t.font.material;
		// set position, make the passed pos parameter as center
		pos.x -= r.bounds.size.x / 2;
		obj.transform.position = pos;
		// add script component
		FlyingText ft = obj.AddComponent<FlyingText> ();
		ft.bTextMesh = true;
		ft.speed = speed;
		ft.duration = duration;
		return ft;
	}
	// Update is called once per frame
	void Update () {
		if (alpha > 0) {
			// change the y position
			Vector3 pos = transform.position;
			pos.y += speed * Time.deltaTime;
			transform.position = pos;
			// change alpha value
			alpha -= Time.deltaTime/duration;
			if( bTextMesh ) {
				TextMesh t = GetComponent<TextMesh> ();
				Color color = t.color;
				color.a = alpha;
				t.color = color;
			} else {
				Text t = GetComponent<Text> ();
				Color color = t.color;
				color.a = alpha;
				t.color = color;
			}
		} else {
			// destroy the game object if it's invisible
			Destroy(gameObject);
		}
	}
}