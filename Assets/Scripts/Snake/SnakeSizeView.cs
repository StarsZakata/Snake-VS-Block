using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Snake))]
public class SnakeSizeView : MonoBehaviour
{
    [SerializeField] private TMP_Text view;

    private Snake snake;

	private void Awake()
	{
		snake = GetComponent<Snake>();
	}

	private void OnEnable()
	{
		snake.SizeUpdated += OnSizeUpdated;
	}

	private void OnDisable()
	{
		snake.SizeUpdated -= OnSizeUpdated;
	}

	private void OnSizeUpdated(int size) {
		view.text = size.ToString();
	}
}
