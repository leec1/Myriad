//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
namespace AssemblyCSharp
{
	public class Soldier : Role
	{
		const ViewStyle view = ViewStyle.topDown;
		public override bool becomeSoldier()
		{
			Console.WriteLine("Already a Soldier!");
			return false;
		}
		
		public override bool becomeCommander()
		{
			bool success = false;
			Console.WriteLine ("Attempting to become the Commander");
			if (CommandBase.Instance.enter(this)) {
				Console.WriteLine ("You are now the commander!");
				success = true;
			} else {
				Console.WriteLine ("You are still a soldier! ");
				// success already false
			}
			return success;
		}

		public Soldier ()
		{

		}
	}
}

