﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockModal : MonoBehaviour {
	void OnDisable () {
    Destroy(this.gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject);
	}
}
