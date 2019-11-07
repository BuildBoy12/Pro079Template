using Smod2.Events;
using Pro079Core.API;
using Smod2.EventHandlers;
using Smod2.API;
using Smod2;

namespace Pro079Template 
{
	class Pro079Ultimate : IEventHandlerWaitingForPlayers, IUltimate079
	{
		private bool doorsBroke = false;
		private readonly Pro079UltimatePlugin plugin; 
		public Pro079Ultimate(Pro079UltimatePlugin plugin)
		{
			this.plugin = plugin;
		}

		// This is an example of why Config Options are not needed, but I do encourage you to do configs.
		public string Name => "breakdoors";

		public string Info => plugin.info;

		// Properties in C# work basically like functions, so you can have 0 cooldowns if certain conditions are met.
		public int Cooldown
		{
			get
			{
				if (doorsBroke)
				{
					plugin.Info("Dumb SCP-079 tried to use the breakdoors ultimate twice.");
					return 0;
				}
				else return plugin.cooldown;
			}
		}

		// The => basically works like a one line function, that's my secret :smug:
		public int Cost => doorsBroke ? 0 : plugin.cost;

		public string TriggerUltimate(string[] args, Player Player)
		{
			foreach(Door door in PluginManager.Manager.Server.Map.GetDoors())
			{
				// I didn't even test this, but probably some Destroyed = true give some exceptions
				try { door.Destroyed = true; } catch { }
			}
			return plugin.yeetus;
		}

		// You need to reset the variables you will use, so do it in the event WaitingForPlayers
		public void OnWaitingForPlayers(WaitingForPlayersEvent ev)
		{
			doorsBroke = false;
		}
	}
}
