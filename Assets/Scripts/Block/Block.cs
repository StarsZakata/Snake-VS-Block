using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class Block : MonoBehaviour
{
    [SerializeField] private Vector2Int destroyPriceRange;
	[SerializeField] private Color[] colors;

	private SpriteRenderer spriteRendere;
    private int destroyPrice;
    private int filling;

	public int LeftToFill => destroyPrice - filling;

	public event UnityAction<int> FillingUpdate;
	private void Start()
	{
		spriteRendere = GetComponent<SpriteRenderer>();
		SetColor(colors[Random.RandomRange(0, colors.Length)]);
		destroyPrice = Random.Range(destroyPriceRange.x, destroyPriceRange.y);
		FillingUpdate?.Invoke(LeftToFill);

	}


	public void Fill() {
		filling++;
		FillingUpdate?.Invoke(LeftToFill);
		if (filling == destroyPrice) {
			Destroy(gameObject);
		}
	}

	private void SetColor(Color color) {
		spriteRendere.color = color;
	}
}
