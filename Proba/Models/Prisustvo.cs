//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Proba.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public partial class Prisustvo
    {
        [Key, Column(Order = 1)]
        public int ClanID { get; set; }
        [Key, Column(Order = 0)]
        public int SednicaID { get; set; }
        public bool Prisutan { get; set; }
        public Nullable<bool> Opravdano { get; set; }
    
        public virtual Clanovi Clanovi { get; set; }
        public virtual Sednice Sednice { get; set; }
    }
}
