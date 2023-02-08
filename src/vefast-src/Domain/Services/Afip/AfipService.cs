using AfipWsfeClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vefast_src.Domain.Entities.Afip;
using AfipServiceReference;

namespace vefast_src.Domain.Services.Afip
{
    public class AfipService : IAfipService
    {

        public async Task GeneratEInvoice()
        {
            var loginClient = new LoginCmsClient { IsProdEnvironment = false };

            var ticket = await loginClient.LoginCmsAsync("wsfe",
                                                         "C:\\afip.p12",
                                                         "jonivss159159",
                                                         true);

            var wsfeClient = new WsfeClient
            {
                IsProdEnvironment = false,
                Cuit = 20360645453,
                Sign = ticket.Sign,
                Token = ticket.Token
            };

            //Get next WSFE Comp. Number
            var compNumber = await wsfeClient.FECompUltimoAutorizadoAsync(1, 6);

            var feCaeReq = new FECAERequest
            {
                FeCabReq = new FECAECabRequest
                {
                    CantReg = 1,
                    CbteTipo = 6,
                    PtoVta = 1
                },
                FeDetReq = new List<FECAEDetRequest>
                {
                    new AfipServiceReference.FECAEDetRequest
                    {
                        CbteDesde = compNumber.Body.FECompUltimoAutorizadoResult.CbteNro + 1,
                        CbteHasta = compNumber.Body.FECompUltimoAutorizadoResult.CbteNro + 1,
                        CbteFch = "20190717",
                        Concepto = 2,
                        DocNro = 30111222,
                        DocTipo = 96,
                        FchVtoPago = "20190718",
                        ImpNeto = 10,
                        ImpTotal = 10,
                        FchServDesde = "20190717",
                        FchServHasta = "20190717",
                        MonCotiz = 1,                        
                        MonId = "PES",
                        Iva = new List<AlicIva>
                        {
                            new AlicIva
                            {
                                BaseImp = 10,
                                Id = 3,
                                Importe = 0
                            }
                        }
                    }
                }
            };


            //Call WSFE FECAESolicitar
            var compResult = await wsfeClient.FECAESolicitarAsync(feCaeReq);

        }
    }
}
