﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Bonus : MonoBehaviour
{
	[SerializeField] private TMP_Text view;
	[SerializeField] private Vector2Int bonusSizeRange;

	private int bonusSize;

	private void Start()
	{
		bonusSize = Random.RandomRange(bonusSizeRange.x, bonusSizeRange.y);
		view.text = bonusSize.ToString();
	}

	public int Collect() {
		Destroy(gameObject);
		return bonusSize;
	}
}
