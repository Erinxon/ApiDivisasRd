using ApiDivisas.Models;
using ApiDivisas.Handles;
using ApiDivisas.AppsettingModels;
using HtmlAgilityPack;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiDivisas.Response;

namespace ApiDivisas.Services
{
    public class DivisaService : IDivisaService
    {
        private readonly SectionUrlPage urlPage;
        private readonly XPath _xPaths;
        public DivisaService(IOptions<SectionUrlPage> sectionUrlPage, IOptions<XPath> xPaths)
        {
            this.urlPage = sectionUrlPage.Value;
            this._xPaths = xPaths.Value;
        }
        public async Task<ApiResponse<Divisa>> GetDivisaAsync()
        {
            var response = new ApiResponse<Divisa>();        
            try
            {
                var htmlDoc = await GetHtmlDocument(); 
                var divisasNodes = htmlDoc.DocumentNode.SelectNodes(_xPaths.XPathGeneral);
                response.Data = new Divisa
                {
                    Dolar = divisasNodes.GetMonedaDolar(_xPaths),
                    Euro = divisasNodes.GetMonedaEuro(_xPaths)
                };
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.message = ex.Message;
            }

            return response;
        }

        private async Task<HtmlDocument> GetHtmlDocument()
        {
            HtmlWeb htmlWeb = new();
            HtmlDocument htmlDoc = await htmlWeb.LoadFromWebAsync(this.urlPage.Url);
            return htmlDoc;
        }
    }

}
