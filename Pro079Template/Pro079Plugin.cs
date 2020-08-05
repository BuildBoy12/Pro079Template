using Exiled.API.Features;
using Pro079Core;
using System;

// Change Pro079Template pressing Ctrl+R Ctrl+R in Visual Studio to whatever you like
namespace Pro079Template
{
	public class Pro079Plugin : Plugin<Config>
	{
		private Pro079Ultimate Ultimate;
		public override void OnEnabled()
        {
            base.OnEnabled();

			// This is how you register the command
			Pro079.Manager.RegisterCommand(new Pro079Command(this));

			// This is how you can handle Ultimates that contain event handlers
			Ultimate = new Pro079Ultimate(this);
			Exiled.Events.Handlers.Server.WaitingForPlayers += Ultimate.OnWaitingForPlayers;

			// This is how you register the ultimate
			Pro079.Manager.RegisterUltimate(Ultimate);
		}

        public override void OnDisabled() 
		{
			base.OnDisabled();
			Exiled.Events.Handlers.Server.WaitingForPlayers -= Ultimate.OnWaitingForPlayers;
		}

        public override string Author => "Joe";
        public override string Name => "Pro079.Template";
        public override Version RequiredExiledVersion => new Version(2, 0, 10);
    }
}