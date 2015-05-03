#pragma strict
class AbstractEnemy {
   public var name: String;
   public var health: int;
   public var obj: GameObject;
   public var position: Vector3;
   function AbstractEnemy(n: String, h: int, pos: Vector3, obje :GameObject) {
      name = n;
      health = h;
      obj = obje;
      position = pos;
      Debug.Log(position);
      obj = GameObject.Instantiate(obj,position,Quaternion.identity);
   }
   function getName(){
   	return name;
   }
   function setName(n: String){
   	name = n;
   }
   function getHealth(){
   	return health;   
   }
   function setHealth(h: int){
  	health = h;
   }
   function takeDamage() {
   	  Debug.Log('DAMAGE FUNCTION NOT IMPLEMENTED');
   }
   function getObj(){
   	return obj;   
   }
   function setPosition(pos: Vector3){
   	position = pos;
   }
   function Update() {
   		var rgbd = this.obj.GetComponent.<Rigidbody>();
   		rgbd.AddForce(Vector3.right*105f);
   }
   
}