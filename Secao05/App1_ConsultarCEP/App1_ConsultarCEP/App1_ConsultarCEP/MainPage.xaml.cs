using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App1_ConsultarCEP.Servico.Modelo;
using App1_ConsultarCEP.Servico;

namespace App1_ConsultarCEP
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            BOTAO.Clicked += BuscarCEP;

		}

        private void BuscarCEP(Object sender, EventArgs args)
        {
            // Lógica do programa
                        
            string cep = CEP.Text.Trim();

            if (isValidCEP(cep)) { 
                try { 
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);

                    if (end != null)
                    { 
                       RESULTADO.Text = string.Format("Endereco: {2} - {3} {0}-{1}", end.localidade, end.uf, end.logradouro, end.bairro);
                    } 
                    else
                    {
                        DisplayAlert("Cep Inválido", "O endereço não foi encontrado para o CEP informado: " + cep, "OK");
                    } 
                } catch(Exception e)
                {
                    DisplayAlert("Erro Crítico", e.Message, "OK");
                }
            }           
        }

        // Validações sobre o CEP

        private bool isValidCEP(string cep)
        {
            bool valido = true;
           
            if (cep.Length != 8)
            {
                DisplayAlert("Erro", "CEP inválido, o CEP deve conter 8 caracteres!", "OK");
                valido = false;
            }
            
            int NovoCEP = 0;

            if (!int.TryParse(cep, out NovoCEP))
            {
                DisplayAlert("Erro", "CEP inválido, o CEP deve ser composto apenas por números!", "OK");
                valido = false;
            }

            return valido;
        }

    }
}
