using UnityEngine;

public class NewUpdate : MonoBehaviour
{
	public bool canDo = false;

	private float timer;
	private float timerMax;

	private void Update()
	{
		if (timer <= timerMax)
		{
			canDo = false;

			timer -= timerMax;
		}
		else
		{
			canDo = true;

			timer += Time.deltaTime;
		}
	}
}
