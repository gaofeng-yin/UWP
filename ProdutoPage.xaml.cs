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
    public sealed partial class ProdutoPage : Page
    {
        public ProdutoPage()
        {
            this.InitializeComponent();
            this.refreshList();
            Tipo.ItemsSource = DbUtil.getInstance().getConnection().Query<TipoProduto>("select * from TipoProduto");
        }
        private void refreshList()
        {
            this.categories.Items.Clear();
            List<Produto> fornecedores = DbUtil.getInstance().getConnection().Query<Produto>("select * from Produto");
            /*
            */
            foreach (Produto supplier in fornecedores)
            {
                this.categories.Items.Add(supplier);
            }
        }

        private void Button_add(object sender, RoutedEventArgs e)
        {
            this.btnSave.Content = "Adicionar";
            this.gridCategoryDetails.Visibility = Visibility.Visible;
            this.name.Focus(FocusState.Programmatic);
            /*
            */
        }

        private void Button_del(object sender, RoutedEventArgs e)
        {
            Produto category = (Produto)this.categories.SelectedItem;
            if (category != null)
            {
                DbUtil.getInstance().getConnection().Delete<Produto>(category.ID);
                this.refreshList();
            }
            /*
            */
        }

        private void Button_save(object sender, RoutedEventArgs e)
        {
            Produto category = (Produto)this.categories.SelectedItem;
            if (category != null)
            {
                // updating supplier
                category.Nome = name.Text;
                category.Preco = Convert.ToDouble(preco.Text);
                string novo = string.Format("select ID from TipoProduto where Nome='{0}'", Tipo.SelectedItem);
                var tipo = DbUtil.getInstance().getConnection().Query<TipoProduto>(novo);
                foreach (var i in tipo)
                    category.IdTipo = i.ID;
                DbUtil.getInstance().getConnection().Update(category);
            }
            else
            {
                // creating new supplier
                category = new Produto();
                category.Nome = name.Text;
                category.Preco = Convert.ToDouble(preco.Text);
                string novo = string.Format("select ID from TipoProduto where Nome='{0}'", Tipo.SelectedItem);
                var tipo = DbUtil.getInstance().getConnection().Query<TipoProduto>(novo);
                foreach (var i in tipo)
                    category.IdTipo = i.ID;
                DbUtil.getInstance().getConnection().Insert(category);
            }
            this.gridCategoryDetails.Visibility = Visibility.Collapsed;
            this.refreshList();
            /*
            */
        }

        private void categories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Produto category = (Produto)this.categories.SelectedItem;
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
    }
}
