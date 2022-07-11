using System;
namespace vefast_src.DTO.Orders
{
    public class OrdersRequest
    {
        public string BillNo { get; set; } /*AGREGAR DESCRIPCION*/
        public string CustomerName { get; set; } /*Nombre del cliente*/
        public string CustomerAddress { get; set; } /*Direccion del cliente*/
        public string CustomerPhone { get; set; } /*Telefono del cliente*/
        public DateTime DateTimeIn { get; set; }
        public double GrossAmount { get; set; } /*Importe bruto*/
        public double ServiceChargeRate { get; set; } /*Tasa de cargo del servicio*/
        public double ServiceCharge { get; set; } /*Importe del cargo por el servicio*/
        public double VatChargeRate { get; set; } /*Tasa de carga del IVA*/
        public double VatCharge { get; set; }/*Importe del IVA*/
        public double NetAmount { get; set; } /*Importe neto*/
        public double Discount { get; set; }/*Descuento*/
        public int PaidStatus { get; set; } /*Estado del pago*/
        public Guid ID_User { get; set; }
        public Guid ID_OrderItem { get; set; }
    }
}
