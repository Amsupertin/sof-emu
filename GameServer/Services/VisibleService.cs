﻿using Communicate.Interfaces;
using Data.Interfaces;
using Data.Models.Creature;
using Data.Models.Player;
using GameServer.Networks.Packets.Response;
using Utility;

namespace GameServer.Services
{
    public class VisibleService : IVisibleService
    {
        public void Action()
        {

        }

        public void Broadcast(Creature creature, ISendPacket packet)
        {
            Player player = creature as Player;

            if (player != null)
                if (player.GetSession() != null)
                    packet.Send(player.GetSession());

            player
                .GetMap()
                .GetPlayers()
                .ForEach(p => packet.Send(p.GetSession()));
        }
    }
}
