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
    public sealed partial class EncomendaPage : Page
    {
        public EncomendaPage()
        {
            this.InitializeComponent();
            Total.IsReadOnly = true;
            NomeCliente.IsReadOnly = true;
            MoradaCliente.IsReadOnly = true;
            TotalDetalhe.IsReadOnly = true;
            ListaProdutos.ItemsSource = DbUtil.getInstance().getConnection().Query<Produto>("select * from Produto");
            Encomendas.ItemsSource = DbUtil.getInstance().getConnection().Query<EncomendaDetalhe>("select * from EncomendaDetalhe");
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = new TextBox();

        }

        private void listView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var a = ListaProdutos.SelectedItems.ToArray();
            double preco = 0;

            foreach (Produto prod in a)
            {
                preco += prod.Preco;
                Total.Text = preco.ToString();
            }

        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            EncomendaDetalhe detalhe = new EncomendaDetalhe();
            int produtoID = 0;
            detalhe.NomeCliente = Nome.Text;
            detalhe.Morada = Morada.Text;
            detalhe.PrecoTotal = Convert.ToDouble(Total.Text);
            var a = ListaProdutos.SelectedItems.ToArray();
            foreach (Produto prod in a)
            {
                produtoID = prod.ID;
            }
            detalhe.ProdutosID = produtoID;
            DbUtil.getInstance().getConnection().Insert(detalhe);

            Encomendas.ItemsSource =  DbUtil.getInstance().getConnection().Query<EncomendaDetalhe>("select * from EncomendaDetalhe");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string a = Encomendas.SelectedItem.ToString();
            string b = string.Format("select * from EncomendaDetalhe where NomeCliente='{0}'", a);
            var enc = DbUtil.getInstance().getConnection().Query<EncomendaDetalhe>(b);

            foreach (var i in enc)
            {
                NomeCliente.Text = i.NomeCliente;
                MoradaCliente.Text = i.Morada;
                TotalDetalhe.Text = i.PrecoTotal.ToString();
                string novo = string.Format("select * from Produto where ID='{0}'", i.ProdutosID);
                ListaDetalhes.ItemsSource = DbUtil.getInstance().getConnection().Query<Produto>(novo);
            }
        }
    }

}
