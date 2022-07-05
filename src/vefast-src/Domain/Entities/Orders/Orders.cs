namespace vefast_src.Domain.Entities.Orders
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using vefast_src.Domain.Entities.OrderItems;
    using vefast_src.Domain.Entities.Users;

    public class Orders : BaseEntity
    {
        public string BillNo { get; set; } /*AGREGAR DESCRIPCION*/
        public string CustomerName { get; set; } /*Nombre del cliente*/
        public string CustomerAddress { get; set; } /*Direccion del cliente*/
        public string CustomerPhone { get; set; } /*Telefono del cliente*/
        public DateTime DateTimeIn { get; set; }
        public double GrossAmount { get; set; } /*Importe bruto*/
        public double ServiceChargeRate {get;set;} /*Tasa de cargo del servicio*/
        public double ServiceCharge { get; set; } /*Importe del cargo por el servicio*/
        public double VatChargeRate { get; set; } /*Tasa de carga del IVA*/
        public double VatCharge { get; set; }/*Importe del IVA*/
        public double NetAmount { get; set; } /*Importe neto*/
        public double Discount { get; set; }/*Descuento*/
        public int PaidStatus { get; set; } /*Estado del pago*/

        [ForeignKey("Users")]
        public Guid ID_User { get; set; }

        [ForeignKey("OrderItems")]
        public Guid ID_OrderItem { get; set; }

        public virtual Users User { get; set; }
        public virtual OrderItems OrderItem { get; set; }
    }
}
