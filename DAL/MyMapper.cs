using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class MyMapper
    {
        public MyMapper()
        {

        }
        public static void getMappingUsers()
        {
            Mapper.CreateMap<DataRow, UtilisateurDAL>()
                .ForMember(dest => dest.Prenom, opt => opt.MapFrom(src => src["Prenom"]))
                .ForMember(dest => dest.Utilisateur_Id, opt => opt.MapFrom(src => src["Utilisateur_Id"]))
                .ForMember(dest => dest.Nom, opt => opt.MapFrom(src => src["Nom"]))
                .ForMember(dest => dest.MotDePasse, opt => opt.MapFrom(src => src["MotDePasse"]))
                .ForMember(dest => dest.AdresseMail, opt => opt.MapFrom(src => src["AdresseMail"]))
                .ForMember(dest => dest.CodePostal, opt => opt.MapFrom(src => src["CodePostal"]))
                .ForMember(dest => dest.DateInscription, opt => opt.MapFrom(src => src["DateInscription"]))
                .ForMember(dest => dest.DateNaissance, opt => opt.MapFrom(src => src["DateNaissance"]))
                .ForMember(dest => dest.Metier, opt => opt.MapFrom(src => src["Metier"]))
                .ForMember(dest => dest.Partenaire, opt => opt.MapFrom(src => src["Partenaire"]))
                .ForMember(dest => dest.PhotoChemin, opt => opt.MapFrom(src => src["PhotoChemin"]))
                .ForMember(dest => dest.Presentation, opt => opt.MapFrom(src => src["Presentation"]))
                .ForMember(dest => dest.Pseudo, opt => opt.MapFrom(src => src["Pseudo"]))
                .ForMember(dest => dest.Sexe, opt => opt.MapFrom(src => src["Sexe"]))
                .ForMember(dest => dest.Situation, opt => opt.MapFrom(src => src["Situation"]))
                .ForMember(dest => dest.Ville, opt => opt.MapFrom(src => src["Ville"]))
                .ForMember(dest => dest.Actif, opt => opt.MapFrom(src => src["Actif"]));
        }
    }
}
