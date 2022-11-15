using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AxiGroep_5.Models;
using LogicaLaag;
using AxiGroep_5.Controllers;
using LogicaLaag.Management;
using LogicaLaag.KlantBestelling;
using LogicaLaag.AlleLocaties;

namespace AxiGroep_5
{
    public class Converter
    {
        public Artikel ViewModelArtikelNaarModel(ArtikelViewModel artikelViewModel)
        {
            ArtikelGroep artikelGroep = new ArtikelGroep(artikelViewModel.ArtikelGroepViewmodel.groepID, artikelViewModel.ArtikelGroepViewmodel.naam);
            Artikel artikel = new Artikel(artikelViewModel.Artikelnaam, artikelViewModel.Aantal, artikelViewModel.Artikelnummer, artikelViewModel.ArtikelID, artikelGroep
                , artikelViewModel.Prijs, artikelViewModel.Beschrijving, artikelViewModel.THT, artikelViewModel.Afmeting, artikelViewModel.Kleur, artikelViewModel.Gewicht);

            return artikel;
        }
        public ArtikelViewModel ModelArtikelNaarViewModel(Artikel artikel)
        {
            ArtikelGroepViewModel artikelGroep = new ArtikelGroepViewModel();
            artikelGroep.groepID = artikel.Artikelgroep.GroepId;
            artikelGroep.naam = artikel.Artikelgroep.Naam;
            ArtikelViewModel artikelViewModel = new ArtikelViewModel();
            artikelViewModel.Artikelnaam = artikel.Artikelnaam;
            artikelViewModel.Aantal = artikel.Aantal;
            artikelViewModel.ArtikelID = artikel.ArtikelID;
            artikelViewModel.Artikelnummer = artikel.ArtikelNummer;
            artikelViewModel.ArtikelGroepViewmodel = artikelGroep;
            artikelViewModel.Prijs = artikel.Prijs;
            artikelViewModel.Beschrijving = artikel.Beschrijving;
            artikelViewModel.THT = artikel.THT;
            artikelViewModel.Afmeting = artikel.Afmeting;
            artikelViewModel.Kleur = artikel.Kleur;
            artikelViewModel.Gewicht = artikel.Gewicht;

            return artikelViewModel;
        }

        public List<ArtikelViewModel> LijstArtikelNaarArtikelViewModel(List<Artikel> artikels)
        {
            List<ArtikelViewModel> artikelViewModels = new List<ArtikelViewModel>();
            foreach (Artikel artikel in artikels)
            {


                ArtikelViewModel artikelViewModel = ModelArtikelNaarViewModel(artikel);
                artikelViewModels.Add(artikelViewModel);
            }
            return artikelViewModels;
        }

        public MagazijnViewModel ModelMagazijnNaarMagazijnViewModel(Magazijn magazijn)
        {
            MagazijnViewModel magazijnViewModel = new MagazijnViewModel
            {
                Naam = magazijn.Naam,
                Id = magazijn.Id,
                Huisnummer = magazijn.Huisnummer,
                Straatnaam = magazijn.Straatnaam,
                Postcode = magazijn.Postcode
            };
            return magazijnViewModel;
        }

        public Magazijn MagazijnViewModelNaarModel(MagazijnViewModel magazijnViewModel)
        {
            Magazijn magazijn = new Magazijn(magazijnViewModel.Id, magazijnViewModel.Naam, magazijnViewModel.Straatnaam, magazijnViewModel.Huisnummer, magazijnViewModel.Postcode);
            return magazijn;
        }

        public Locatie LocatieViewModelNaarLocatie(LocatieViewModel model)
        {
            Locatie locatie = new Locatie(model.LocatieId, model.MagazijnId, model.RijNummer, model.NiveauId, model.PlekId, model.ArtikelId, model.IsBezet, model.AantalInLocatie);
            return locatie;
        }

        public LocatieViewModel LocatieNaarlocatieViewModel(Locatie locatie)
        {
            LocatieViewModel locatieViewModel = new LocatieViewModel
            {
                LocatieId = locatie.LocatieId,
                MagazijnId = locatie.MagazijnId,
                RijNummer = locatie.RijNummer,
                NiveauId = locatie.NiveauId,
                PlekId = locatie.PlekId,
                ArtikelId = locatie.ArtikelId,
                IsBezet = locatie.IsBezet,
                AantalInLocatie = locatie.AantalInLocatie
            };
            return locatieViewModel;
        }

        public Management ManagementViewModelNaarManagementModel(ManagementViewModel managementViewModel)
        {
            Management management = new Management(managementViewModel.id, managementViewModel.Email, managementViewModel.Password, managementViewModel.PriorityLevel);
            return management;
        }

        public ManagementViewModel ModelManagementNaarManagementViewModel(Management management)
        {
            ManagementViewModel managementViewModel = new ManagementViewModel { id = management.id, Email = management.Email, Password = management.Password, PriorityLevel = management.PriorityLevel };
            return managementViewModel;
        }

        public List<ManagementViewModel> LijstManagementNaarManagementViewModel(List<Management> management)
        {
            List<ManagementViewModel> managementViewModels = new List<ManagementViewModel>();
            foreach (Management management1 in management)
            {
                ManagementViewModel managementViewModel = ModelManagementNaarManagementViewModel(management1);
                managementViewModels.Add(managementViewModel);
            }
            return managementViewModels;
        }
        public ArtikelGroep ViewModelArtikelGroepNaarModel(ArtikelGroepViewModel artikelGroepViewModel)
        {
            ArtikelGroep artikelGroep = new ArtikelGroep(artikelGroepViewModel.groepID, artikelGroepViewModel.naam, artikelGroepViewModel.Beschrijving);
            return artikelGroep;
        }
        public ArtikelGroepViewModel ModelNaarArtikelGroepViewModel(ArtikelGroep artikelGroep)
        {
            ArtikelGroepViewModel artikelGroepViewModel = new ArtikelGroepViewModel
            {
                naam = artikelGroep.Naam,
                Beschrijving = artikelGroep.Beschrijving,
                groepID = artikelGroep.GroepId
            };
            return artikelGroepViewModel;
        }
        public List<ArtikelGroepViewModel> LijstArtikelGroepModelNaarViewModel(List<ArtikelGroep> artikelgroepen)
        {
            List<ArtikelGroepViewModel> artikelGroepViewModels = new List<ArtikelGroepViewModel>();
            foreach (ArtikelGroep artikelGroep in artikelgroepen)
            {
                ArtikelGroepViewModel groepViewModel = ModelNaarArtikelGroepViewModel(artikelGroep);
                artikelGroepViewModels.Add(groepViewModel);
            }
            return artikelGroepViewModels;
        }

        public KlantBestellingModel ModelKlantBestellingNaarKlantBestellingViewModel(KlantBestelling klantBestelling)
        {
            if (klantBestelling.Artikelnaam == null)
            {
                KlantBestellingModel klantBestellingModel = new KlantBestellingModel { BestellingID = klantBestelling.BestellingID, Artikelaantal = klantBestelling.Artikelaantal, DagTijd = klantBestelling.DagTijd, ArtikelID = klantBestelling.BesteldeArtikelID };
                return klantBestellingModel;
            }
            else
            {
                KlantBestellingModel klantBestellingModel = new KlantBestellingModel { ArtikelNaam = klantBestelling.Artikelnaam, Artikelaantal = klantBestelling.Artikelaantal, ArtikelID = klantBestelling.BesteldeArtikelID };
                return klantBestellingModel;
            }
        }
        public List<KlantBestellingModel> KlantBestellingNaarKlantBestellingModel(List<KlantBestelling> klantBestelling)
        {
            List<KlantBestellingModel> klantBestellingen = new List<KlantBestellingModel>();
            foreach (KlantBestelling klantBestelling1 in klantBestelling)
            {
                if (klantBestellingen.Count == 0)
                {
                    KlantBestellingModel klantBestellingModel = ModelKlantBestellingNaarKlantBestellingViewModel(klantBestelling1);
                    klantBestellingen.Add(klantBestellingModel);
                }
                else
                {
                    KlantBestellingModel klantBestellingModel = ModelKlantBestellingNaarKlantBestellingViewModel(klantBestelling1);
                    klantBestellingen.Add(klantBestellingModel);
                }
            }
            return klantBestellingen;
        }

        public Artikel ViewModelArtikelNaarModelVoorBestellen(ArtikelViewModel artikelViewModel)
        {

            Artikel artikel = new Artikel(artikelViewModel.Artikelnaam, artikelViewModel.Aantal, artikelViewModel.Artikelnummer, artikelViewModel.ArtikelID
                , artikelViewModel.Prijs, artikelViewModel.Beschrijving);

            return artikel;
        }
        public List<Artikel> ViewModelListNaarModelList(List<ArtikelViewModel> artikelViewModels)
        {
            List<Artikel> artikels = new List<Artikel>();
            foreach (ArtikelViewModel artikelViewModel in artikelViewModels)
            {
                ArtikelGroep artikelGroep = new ArtikelGroep(artikelViewModel.ArtikelGroepViewmodel.groepID, artikelViewModel.ArtikelGroepViewmodel.naam);
                Artikel artikel = new Artikel(artikelViewModel.Artikelnaam, artikelViewModel.Aantal, artikelViewModel.Artikelnummer, artikelViewModel.ArtikelID, artikelGroep
                    , artikelViewModel.Prijs, artikelViewModel.Beschrijving, artikelViewModel.THT, artikelViewModel.Afmeting, artikelViewModel.Kleur, artikelViewModel.Gewicht);
                artikels.Add(artikel);
            }
            return artikels;
        }
        public List<LocatieViewModel> LijstLocatieModelNaarLijstViewModel(List<Locatie> locaties)
        {
            List<LocatieViewModel> locatieViewModels = new List<LocatieViewModel>();
            foreach(Locatie locatie in locaties)
            {
                LocatieViewModel locatieViewModel = new LocatieViewModel
                {
                    LocatieId = locatie.LocatieId,
                    AantalInLocatie = locatie.AantalInLocatie,
                    ArtikelId = locatie.ArtikelId,
                    IsBezet = locatie.IsBezet,
                    MagazijnId = locatie.MagazijnId,
                    NiveauId = locatie.NiveauId,
                    PlekId = locatie.PlekId,
                    RijNummer = locatie.RijNummer

                };
                locatieViewModels.Add(locatieViewModel);
            }
            return locatieViewModels;
        }
    }
}
