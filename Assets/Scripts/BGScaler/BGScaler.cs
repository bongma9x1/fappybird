using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScaler : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Vector3 tempScale = transform.localScale;

        float height = sr.bounds.size.y;
        float width = sr.bounds.size.x;

        float backGroundHeight = Camera.main.orthographicSize * 2f;
        float backGroundWidth = backGroundHeight * Screen.width / Screen.height;
        transform.localScale = new Vector3(backGroundWidth, backGroundHeight, 0);

        tempScale.y = backGroundHeight/height;
        tempScale.x = backGroundWidth / width;
        transform.localScale = tempScale;
	}
}
