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

		Commander currentCommander = null;

		bool isOccupied = false;

		public CommandBase (){}

		public static CommandBase Instance {
			get {
				return instance;
			}
		}

		public static bool enter( Commander newCommander )
		{
			bool success = false;
			if (!isOccupied) {
				lock (instance) {
					currentCommander = newCommander;
					isOccupied = true;
				}
				success = true;
			} else {
				if (currentCommander.giveUpCommander ()) {
					lock (instance) {
						currentCommander = newCommander;
						isOccupied = true;
					}
					success = true;
				} else {
					Console.WriteLine ("Already have a commander and they don't want to give it up!");
					// Success already set to false
				}
			}


		}
	}
}
