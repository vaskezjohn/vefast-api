﻿using System;
namespace vefast_src.DTO.Orders
{
    public class OrdersResponse
    {
        public string bill_no { get; set; } /*AGREGAR DESCRIPCION*/
        public string customer_name { get; set; } /*Nombre del cliente*/
        public string customer_address { get; set; } /*Direccion del cliente*/
        public string customer_phone { get; set; } /*Telefono del cliente*/
        public DateTime date_time { get; set; }
        public double gross_amount { get; set; } /*Importe bruto*/
        public double service_charge_rate { get; set; } /*Tasa de cargo del servicio*/
        public double service_charge { get; set; } /*Importe del cargo por el servicio*/
        public double vat_charge_rate { get; set; } /*Tasa de carga del IVA*/
        public double vat_charge { get; set; }/*Importe del IVA*/
        public double net_amount { get; set; } /*Importe neto*/
        public double discount { get; set; }/*Descuento*/
        public int paid_status { get; set; } /*Estado del pago*/
        public Guid users_id { get; set; }
        public Guid orders_item_id { get; set; }
    }
}
