#pragma strict

internal var flag = false;

function OnBecameVisible () {
	flag = true;
}

function OnBecameInvisible () {
	if (flag) {
		Destroy (this.transform.parent.gameObject);
	}
}