//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SoccerStats.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_Entraineur
    {
        public int idEntraineur { get; set; }
        public int idClub { get; set; }
        public string nomEntraineur { get; set; }
        public string nationaliteEntraineur { get; set; }
    
        public virtual T_Club T_Club { get; set; }
    }
}
