using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Block))]
public class BlockPrice : MonoBehaviour
{
	[SerializeField] private TMP_Text view;

	private Block block;

	private void Awake()
	{
		block = GetComponent<Block>();
	}

	private void OnEnable()
	{
		block.FillingUpdate += OnFillingUpdate;
	}

	private void OnDisable()
	{
		block.FillingUpdate -= OnFillingUpdate;
	}

	private void OnFillingUpdate(int lefttOfILL) {
		view.text = lefttOfILL.ToString();
	}
}
