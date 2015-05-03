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
	public sealed class CommandBase
	{
		private static readonly CommandBase instance = new CommandBase();

		private Commander currentCommander = null;

		private bool isOccupied = false;

		private int currentHealth;
		private int maxHealth;

		public CommandBase (){}

		public static CommandBase Instance {
			get {
				return instance;
			}
		}

		public bool enter( Role newCommander )
		{
			bool success = false;
			if (!instance.isOccupied) {
				lock (instance) {
					instance.currentCommander = (Commander) newCommander;
					instance.isOccupied = true;
				}
				success = true;
			} else {
				if (instance.currentCommander.promptLeave()) {
					lock (instance) {
						instance.currentCommander = (Commander) newCommander;
						instance.isOccupied = true;
					}
					success = true;
				} else {
					Console.WriteLine ("Already have a commander and they don't want to give it up!");
					// Success already set to false
				}
			}

			return success;
		}

		public bool leave( Commander commander )
		{
			bool success = false;
			if (instance.currentCommander.Equals ( commander ) ){
				lock (instance) {
					instance.currentCommander = null;
				}
				success = true;
				Console.WriteLine ("You are leaving the command base unoccupied, is this the best idea?");
			} else {
				Console.WriteLine ("You aren't the Commander! You can't leave!");
				// Success already set to false!
			}
			return success;
		}
	}
}

