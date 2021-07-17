using ApiDivisas.Models;
using ApiDivisas.Response;
using HtmlAgilityPack;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDivisas.Services
{
    public class DivisaService : IDivisaService
    {
        private readonly SectionUrlPage _sectionUrlPage;

        public DivisaService(IOptions<SectionUrlPage> sectionUrlPage)
        {
            this._sectionUrlPage = sectionUrlPage.Value;
        }
        public async Task<Divisa> GetDivisaAsync()
        {
            var htmlDoc = await GetHtmlDocument();
            var infoDolar = htmlDoc.DocumentNode
                .SelectNodes(@"//div[@class='compra']/p[@class='font-700']");
            var infoEuro = htmlDoc.DocumentNode
                .SelectNodes(@"//div[@class='venta']/div/p");
            
            var dolar = new Dolar { 
                Compra = infoDolar[(int)OperacionMoneda.Compra].InnerText,
                Venta = infoDolar[(int)OperacionMoneda.Venta].InnerText 
            };       
            var euro = new Euro { 
                Compra = infoEuro[(int)OperacionMoneda.Venta].InnerText, 
                Venta = infoEuro[(int)OperacionMoneda.Venta].InnerText 
            };
            var divisa = new Divisa  { Dolar = dolar, Euro = euro };

            return divisa;
        }

        private async Task<HtmlDocument> GetHtmlDocument()
        {
            HtmlWeb htmlWeb = new();
            HtmlDocument htmlDoc = await htmlWeb.LoadFromWebAsync(this._sectionUrlPage.Url);
            return htmlDoc;
        }
    }

    public enum OperacionMoneda
    {
        Compra, Venta
    }
}
