using AxiGroep_5.Models;
using LogicaLaag;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


namespace AxiGroep_5.HelperClasses
{
    public class SessieBehandelaar
    {
        HttpContext Context;

        public SessieBehandelaar(HttpContext context)
        {
            Context = context;
        }

        // Uses the sessionhandler to add a list to the session.
        public bool ToevoegenArtikelVMList(List<ArtikelViewModel> ArtikelVMList, string keyName)
        {
            try
            {
                Context.Session.SetString(keyName, SerializeHelper.Serielise(ArtikelVMList));
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        } 

        public List<ArtikelViewModel> OphalenArtikelVMList(string keyName)
        {
            string serializedObj = Context.Session.GetString(keyName);
            List<ArtikelViewModel> artikels;

            if (serializedObj != null)
            {
                artikels = SerializeHelper.Deserieliase<List<ArtikelViewModel>>(serializedObj);
            }
            else
            {
                artikels = null;
            }

            return artikels;
        }

        public bool ToevoegenWinkelmandje(List<ArtikelViewModel> winkelmandje)
        {
            try
            {
                Context.Session.SetString("Winkelmandje", SerializeHelper.Serielise(winkelmandje));
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public List<ArtikelViewModel> OphalenWinkelmandje()
        {
            string serializedObj = Context.Session.GetString("Winkelmandje");
            List<ArtikelViewModel> artikels;

            if (serializedObj != null)
            {
                artikels = SerializeHelper.Deserieliase<List<ArtikelViewModel>>(serializedObj);
            }
            else
            {
                artikels = null;
            }

            return artikels;
        }

    }
}
