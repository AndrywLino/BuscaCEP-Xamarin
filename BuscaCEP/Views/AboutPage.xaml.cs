using BuscaCEP.Models;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace BuscaCEP.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();

            Pin pinteste = new Pin()
            {
                Type = PinType.Place,
                Label = "Paulista",
                Address = "Av. Paulista 100 - Bela Vista",
                Position = new Position(-23.557d, -46.660d),
                Tag = "id_paulista"
            };

            map.Pins.Add(pinteste);
            map.MoveToRegion(MapSpan.FromCenterAndRadius(pinteste.Position, Distance.FromMeters(1000)));
        }

        public async void VerificarCEP(object sender, EventArgs e)
        {
            try
            {
                var location = await Geolocation.GetLocationAsync();

                string entVerificarCep = EntVerificarCep.Text;

                string url = String.Format("https://viacep.com.br/ws/{0}/json/", entVerificarCep);
                RestClient restClient = new RestClient(url);
                RestRequest restRequest = new RestRequest(Method.GET);

                IRestResponse restResponse = restClient.Execute(restRequest);

                CEPModel retorno = new JsonDeserializer().Deserialize<CEPModel>(restResponse);

                LblExibirCep.Text = string.Format("CEP: {0}", retorno.cep);
                LblExibirCep.IsVisible = true;
                LblExibirCep.TextColor = Color.White;

                LblExibirLogradouro.Text = string.Format("Logradouro: {0}", retorno.logradouro);
                LblExibirLogradouro.IsVisible = true;

                if (retorno.complemento != "")
                {
                    LblExibirComplemento.Text = string.Format("Complemento: {0}", retorno.complemento);
                    LblExibirComplemento.IsVisible = true;
                }
                else
                {
                    LblExibirComplemento.IsVisible = false;
                }

                LblExibirBairro.Text = string.Format("Bairro: {0}", retorno.bairro);
                LblExibirBairro.IsVisible = true;

                LblExibirLocalidade.Text = string.Format("Localidade: {0}", retorno.localidade);
                LblExibirLocalidade.IsVisible = true;

                LblExibirUf.Text = string.Format("Estado: {0}", retorno.uf);
                LblExibirUf.IsVisible = true;

                LblExibirDDD.Text = string.Format("DDD: {0}", retorno.ddd);
                LblExibirDDD.IsVisible = true;
            }
            catch
            {
                LblExibirCep.Text = "CEP não Encontrado!";
                LblExibirCep.IsVisible = true;
                LblExibirCep.TextColor = Color.Red;

                LblExibirLogradouro.IsVisible = false;
                LblExibirComplemento.IsVisible = false;
                LblExibirBairro.IsVisible = false;
                LblExibirLocalidade.IsVisible = false;
                LblExibirUf.IsVisible = false;
                LblExibirDDD.IsVisible = false;
            }
        }
    }
}