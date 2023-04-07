using System.Collections.Generic;
using UnityEngine;

public class RandomTreeColor : MonoBehaviour
{
	private List<SpriteRenderer> sprites = new List<SpriteRenderer>();
	private Color color;

	private void Start()
	{
		sprites.AddRange(GetComponentsInChildren<SpriteRenderer>());
		color = Random.ColorHSV(0f, 1f, 0.5f, 0.9f, 0.3f, 0.7f);
	}

	private void Update()
	{
		foreach (SpriteRenderer sprite in sprites)
		{
			if (sprite.tag == "Cell")
			{
				sprite.color = color;
			}
		}
	}
}