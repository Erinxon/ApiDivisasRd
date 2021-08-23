using ApiDivisas.AppsettingModels;
using ApiDivisas.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDivisas.Handles
{
    public static class Handle
    {
        public static Dolar GetMonedaDolar(this HtmlNodeCollection htmlNodes, XPath xPath)
        {
            var dolar = htmlNodes.Select(t => new Dolar
            {
                Compra = t.SelectSingleNode(xPath.XPathCompraDolar).GetAttributeValue("value", ""),
                Venta = t.SelectSingleNode(xPath.XPathVentaDolar).GetAttributeValue("value", ""),
                UltimaActualizacion = t.SelectSingleNode(xPath.XPathUltimaActualizacion).InnerText.Replace("Tasa del ", "")
            }).SingleOrDefault();
            return dolar;
        }

        public static Euro GetMonedaEuro(this HtmlNodeCollection htmlNodes, XPath xPath)
        {
            var euro = htmlNodes.Select(t => new Euro
            {
                Compra = t.SelectSingleNode(xPath.XPathCompraEuro).GetAttributeValue("value", ""),
                Venta = t.SelectSingleNode(xPath.XPathVentaEuro).GetAttributeValue("value", ""),
                UltimaActualizacion = t.SelectSingleNode(xPath.XPathUltimaActualizacion).InnerText.Replace("Tasa del ", "")
            }).SingleOrDefault();
            return euro;
        }
    }
}
