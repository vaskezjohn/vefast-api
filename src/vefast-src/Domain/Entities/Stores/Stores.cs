using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace vefast_src.Domain.Entities.Stores

{
    using vefast_src.Domain.Entities.Company; //importo la entidad a relacionar
    public class Stores : BaseEntity
    {
        public string name { get; set; }
        public bool active { get; set; }

        /*ForeignKey*/
        [ForeignKey("Company")]/*Notacion*/
        public Guid CompanyID { get; set; }
        /* variable virtual de clase Company para formar el FK*/
        public virtual Company Company { get; set; }
    }
}
