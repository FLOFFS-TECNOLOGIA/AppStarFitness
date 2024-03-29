﻿using AppStarFitness.DataService;
using AppStarFitness.Model;
using Newtonsoft.Json;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppStarFitness.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AreaDoUsuario : ContentPage
    {
        string id_tipo;
        public  AreaDoUsuario()
        {
            InitializeComponent();

            btnimg_fotoperfil.Source = ImageSource.FromResource("AppStarFitness.Imagens.default.jpg");
        }

        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();

                string cpf_aluno = (string)Application.Current.Properties["usuario_logado"];
                string senha_aluno = (string)Application.Current.Properties["usuario_senha"];

                Usuario u = await DataServicePessoa.AutenticarPessoa(new Pessoa
                {
                    document = cpf_aluno,
                    password = senha_aluno
                });

                Pessoa p = u.user;

                lbl_nome.Text = p.name.Split(' ')[0];

                id_tipo = p.gymMember.id_type_enrollment;
                //btnimg_fotoperfil.Source = p.photo_url;
            }
            catch(Exception err) 
            {
                await DisplayAlert("Erro", err.Message, "OK");
            }
        }

        private async void btnimg_fotoperfil_Clicked(object sender, EventArgs e)
        {
            try
            {
                var resultado = await MediaPicker.PickPhotoAsync(new MediaPickerOptions());

                if (resultado != null) 
                {
                    var stream = await resultado.OpenReadAsync();

                    btnimg_fotoperfil.Source = ImageSource.FromStream(() => stream);
                }
            }
            catch (Exception err)
            {
                await DisplayAlert(err.Message, err.StackTrace, "OK");
            }
        }

        private void btn_ficha_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new MainPageTreino());
            }
            catch (Exception err)
            {
                DisplayAlert(err.Message, err.StackTrace, "OK");
            }
        }


        private void bnt_dieta_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new MainPageDietas());
            }
            catch (Exception err)
            {
                DisplayAlert(err.Message, err.StackTrace, "OK");
            }
        }

        private void btn_informacoes_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new MainPageInformacoes(id_tipo));
            }
            catch (Exception err)
            {
                DisplayAlert(err.Message, err.StackTrace, "OK");
            }
        }

        private void btn_evolucao_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new Evolucao());
            }
            catch (Exception err)
            {
                DisplayAlert(err.Message, err.StackTrace, "OK");
            }
        }
    }
}