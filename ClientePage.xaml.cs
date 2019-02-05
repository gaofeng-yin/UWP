using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=234238

namespace garraf
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class ClientePage : Page
    {
        public ClientePage()
        {
            this.InitializeComponent();
            this.refreshList();
        }
        private void refreshList()
        {
            this.categories.Items.Clear();
            List<Cliente> fornecedores = DbUtil.getInstance().getConnection().Query<Cliente>("select * from Cliente");
            /*
            */
            foreach (Cliente supplier in fornecedores)
            {
                this.categories.Items.Add(supplier);
            }
        }

        private void Button_add(object sender, RoutedEventArgs e)
        {
            this.btnSave.Content = "Adicionar";
            this.gridCategoryDetails.Visibility = Visibility.Visible;
            this.name.Focus(FocusState.Programmatic);
            this.BTSave.Content = "Adicionar";
            this.gridmoradaDetails.Visibility = Visibility.Visible;
            this.living.Focus(FocusState.Programmatic);
            this.CPBSave.Content = "Adicionar";
            this.gridcodigopostalDetails.Visibility = Visibility.Visible;
            this.CodPostal.Focus(FocusState.Programmatic);
            /*
            /*
            */
        }

        private void Button_del(object sender, RoutedEventArgs e)
        {
            Cliente category = (Cliente)this.categories.SelectedItem;
            if (category != null)
            {
                DbUtil.getInstance().getConnection().Delete<Cliente>(category.IDCliente);
                DbUtil.getInstance().getConnection().Delete<Cliente>(category.Nome);
                DbUtil.getInstance().getConnection().Delete<Cliente>(category.Morada);
                DbUtil.getInstance().getConnection().Delete<Cliente>(category.CodigPostal);
                this.refreshList();
            }
            /*
            */
        }

        private void Button_save(object sender, RoutedEventArgs e)
        {
            Cliente category = (Cliente)this.categories.SelectedItem;
            if (category != null)
            {
                // updating supplier
                category.Nome = name.Text;
                category.Morada = living.Text;
                category.CodigPostal = CodPostal.CharacterSpacing;
                DbUtil.getInstance().getConnection().Update(category);


            }
            else
            {
                // creating new supplier
                category = new Cliente();
                category.Nome = name.Text;
                category.Morada = living.Text;
                category.CodigPostal = CodPostal.CharacterSpacing;
                DbUtil.getInstance().getConnection().Insert(category);
            }
            this.gridCategoryDetails.Visibility = Visibility.Collapsed;
            this.refreshList();
            /*
            */
        }

        private void categories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Cliente category = (Cliente)this.categories.SelectedItem;
            if (category != null)
            {
                this.btnDeleteCategory.IsEnabled = true;
                this.name.Text = category.Nome;
                this.btnSave.Content = "Atualizar";
                this.gridCategoryDetails.Visibility = Visibility.Visible;
                this.name.Focus(FocusState.Programmatic);
                /*
                */
            }
            else
            {
                this.btnDeleteCategory.IsEnabled = false;
                this.name.Text = "";
                this.gridCategoryDetails.Visibility = Visibility.Collapsed;
                /*
                */
            }
        }
        private void morada_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Cliente category = (Cliente)this.categories.SelectedItem;
            if (category != null)
            {
                this.btnDeleteCategory.IsEnabled = true;
                this.living.Text = category.Morada;
                this.BTSave.Content = "Atualizar";
                this.gridmoradaDetails.Visibility = Visibility.Visible;
                this.living.Focus(FocusState.Programmatic);
                /*
                */
            }
            else
            {
                this.btnDeleteCategory.IsEnabled = false;
                this.living.Text = "";
                this.gridmoradaDetails.Visibility = Visibility.Collapsed;
                /*
                */
            }
        }
        private void codigopostal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Cliente category = (Cliente)this.categories.SelectedItem;
            if (category != null)
            {
                this.btnDeleteCategory.IsEnabled = true;
                this.CodPostal.CharacterSpacing = category.CodigPostal;
                this.CPBSave.Content = "Atualizar";
                this.gridcodigopostalDetails.Visibility = Visibility.Visible;
                this.CodPostal.Focus(FocusState.Programmatic);
                /*
                */
            }
            else
            {
                this.btnDeleteCategory.IsEnabled = false;
                this.CodPostal.Text = "";
                this.gridmoradaDetails.Visibility = Visibility.Collapsed;
                /*
                */
            }
        }
    }
}
