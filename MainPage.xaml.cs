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

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x416

namespace garraf 
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void IconsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Encomenda_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ListBox_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            this.splitView.IsPaneOpen = false;
        }

        private void ListBox_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            this.splitView.IsPaneOpen = true;
        }


        private void menu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var menuSelecionado = (Windows.UI.Xaml.FrameworkElement)this.menu.SelectedItem;
            switch (menuSelecionado.Name)
            {
                case "mnEncomenda":
                    this.layoutContent.Navigate(typeof(EncomendaPage));
                    break;
                case "mnMenu":
                    this.layoutContent.Navigate(typeof(Menu));
                    break;
                case "mnPedidos":
                    this.layoutContent.Navigate(typeof(Pedidos));
                    break;
                case "mnRelatorioP":
                    this.layoutContent.Navigate(typeof(RelatorioP));
                    break;
                case "mnFornecedores":
                    this.layoutContent.Navigate(typeof(FornecedoresPage));
                    break;
                case "mnProdutos":
                    this.layoutContent.Navigate(typeof(ProdutoPage));
                    break;
                case "mnCliente":
                    this.layoutContent.Navigate(typeof(ClientePage));
                    break;
            }
        }

    }
}
