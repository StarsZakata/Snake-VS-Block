using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeInput : MonoBehaviour{

    private Camera camera;

	private void Start()
	{
		camera = Camera.main;
	}

	public Vector2 GetDirectionToClick(Vector2 headPosition) {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = camera.ScreenToViewportPoint(mousePosition);
		
		//привязка верхней части экрана
		mousePosition.y = 1;
		mousePosition = camera.ViewportToWorldPoint(mousePosition);

		Vector2 direction = new Vector2(mousePosition.x - headPosition.x, mousePosition.y - headPosition.y);
        return direction;
	}
}
