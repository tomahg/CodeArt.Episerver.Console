﻿using CodeArt.Episerver.DevConsole.Attributes;
using CodeArt.Episerver.DevConsole.Interfaces;
using EPiServer;
using EPiServer.ServiceLocation;
using EPiServer.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeArt.Episerver.DevConsole.Commands
{
    [Command(Keyword = "sites", Description = "Lists all registered sites")]
    public class SitesCommand : IOutputCommand
    {
        public event CommandOutput OnCommandOutput;


        public string Execute(params string[] parameters)
        {
            var repo = ServiceLocator.Current.GetInstance<ISiteDefinitionRepository>();
            int cnt = 0;


            foreach (var r in repo.List())
            {
                OnCommandOutput?.Invoke(this, r);
                cnt++;
            }

            return $"Done, listing {cnt} sites";
        }
    }
}
    
