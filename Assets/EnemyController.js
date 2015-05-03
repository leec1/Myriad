#pragma strict
var enemies =  new Array();
function Start () {
	this.buildEnemies();
}

function Update () {
	for(var enemy : EnemyA in enemies) {
		enemy.Update();
	}
}

function buildEnemies() {
	var cloneable = GameObject.Find("EnemyCylinder");
	var rgdbd = cloneable.GetComponent.<Rigidbody>().transform;
	for (var i=-25; i<65; i+=1) {
		for (var j=20; j>0; j-=1) {
	  		enemies.Push(new EnemyA(Vector3(rgdbd.position.x+j,rgdbd.position.y+1,rgdbd.position.z+i),cloneable));
	  	}
	}
}