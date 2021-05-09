using System;
using UnityEngine;
using UnityEngine.UI;

public class AttributeManager : MonoBehaviour {
	public Text attributesText;
	private int attributes = 0;
	private int doorType = 0;

	private void OnCollisionEnter(Collision collision) {
		string tag = collision.gameObject.tag;
		if(tag.Contains("KEY")) {
			parseKey(tag);
			Destroy(collision.gameObject);
		} else if(tag.Contains("DOOR")) {
			parseDoor(tag);
			if((attributes & doorType) == doorType) {
				collision.gameObject.GetComponent<BoxCollider>().isTrigger = true;
			}
		}
	}

	void OnTriggerExit(Collider other) {
		other.gameObject.GetComponent<BoxCollider>().isTrigger = false;
		attributes &= ~doorType;
	}
	private void parseKey(string tag) {
		if(tag == "CHARISMAKEY") {
			attributes |= (int)Attributes.CHARISMA;
		} else if(tag == "FLYKEY") {
			attributes |= (int)Attributes.FLY;
		} else if(tag == "INTELLIGENCEKEY") {
			attributes |= (int)Attributes.INTELLIGENCE;
		} else if(tag == "INVISIBLEKEY") {
			attributes |= (int)Attributes.INVISIBLE;
		} else if(tag == "MAGICKEY") {
			attributes |= (int)Attributes.MAGIC;
		}
	}
	private void parseDoor(string tag) {
		if(tag == "CHARISMADOOR") {
			doorType = (int)Attributes.CHARISMA;
		} else if(tag == "FLYDOOR") {
			doorType = (int)Attributes.FLY;
		} else if(tag == "INTELLIGENCEDOOR") {
			doorType = (int)Attributes.INTELLIGENCE;
		} else if(tag == "INVISIBLEDOOR") {
			doorType = (int)Attributes.INVISIBLE;
		} else if(tag == "MAGICDOOR") {
			doorType = (int)Attributes.MAGIC;
		}
	}

	// Update is called once per frame
	void Update() {
		attributesText.transform.position = Camera.main.WorldToScreenPoint(transform.position) + new Vector3(60f , -60f , 0f);
		attributesText.text = Convert.ToString(attributes , 2).PadLeft(8 , '0');
	}
}
