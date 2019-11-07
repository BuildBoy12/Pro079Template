﻿using Pro079Core.API;
using Smod2;
using Smod2.API;

namespace Pro079Template
{
	class Pro079Command : ICommand079
	{
		// Just your usual constructor, look it up in Google if you don't know what it is.
		private readonly Pro079Plugin plugin;
		public Pro079Command(Pro079Plugin plugin) => this.plugin = plugin;

		public bool Disabled
		{
			get => plugin.enable;
			
			// Set will just discard the value, or you can get cheeky with it ;)
			set => _ = value;
		}

		// THIS is the reason why you should want to use lang options.
		public string Command => plugin.templatecmd;
		// If you don't want the server owner to change it, you can instead do what's commented:
		// public string Command => "myCommand";

		// Same deal for every other property.
		public string ExtraArguments => plugin.templateExtra;

		public string HelpInfo => plugin.templateUsage;

		// Cassie is either true or false. You can do a config for it, but I don't see the reason why.
		// This boolean is used to set on cooldown every other command that uses C.A.S.S.I.E. so 079 
		// can't earrape or spam messages, which can be very annoying
		public bool Cassie => true;

		public int Cooldown => plugin.cooldown;

		public int MinLevel => plugin.level;

		public int APCost => plugin.cost;

		public string CommandReady => plugin.templateReady;

		// This is enough, you could use variables or take them directly from the time or whatever by yourself
		// but Pro079 will reset the cooldowns to 0 after every round for every single command, so that's
		// been taken care of for you. tl;dr: leave this as it is if you don't need to do anything with it.
		public int CurrentCooldown { get; set; }

		// This is the function where the logic of the command should probably go.
		public string CallCommand(string[] args, Player Player, CommandOutput Output)
		{
			if(args.Length == 0)
			{
				// Use the Output argument in case there was an error, or else AP will be drained and
				// the command will be set on cooldown
				Output.Success = false;
				return plugin.templateUsageError;
			}
			foreach(Door door in PluginManager.Manager.Server.Map.GetDoors())
			{
				if (door.Name == $"GATE_{args[0].ToUpperInvariant()}")
				{
					door.Open = !door.Open;
					return Pro079Core.Configs.Instance.CommandSuccess;
				}
			}
			// Use the Output argument in case there was an error, or else
			Output.CustomReturnColor = true;
			Output.Success = false;
			return $"<color=#F00>Fatal error</color>: gate {args[0]} not found.";
		}
	}
}
