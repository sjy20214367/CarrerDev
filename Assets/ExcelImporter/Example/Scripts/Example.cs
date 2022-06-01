using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class Example : MonoBehaviour
{
	[SerializeField] 
	private MstItems mstItems;
	[SerializeField] 
	private TextMeshProUGUI text;

	private void Start()
	{
		ShowItems();
	}
	private void ShowItems()
	{
		string str = "";

		mstItems.Entities
			.ForEach(entity => str += DescribeMstItemEntity(entity) + "\n");

		text.text = str;
	}

	private string DescribeMstItemEntity(MstItemEntity entity)
	{
		return string.Format(
			"{0} : {1}, {2}, {3}, {4}, {5}",
			entity.id,
			entity.name,
			entity.price,
			entity.isNotForSale,
			entity.rate,
			entity.category
		);
	}
}

