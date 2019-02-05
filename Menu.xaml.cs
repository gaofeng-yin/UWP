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
    public sealed partial class Menu : Page
    {
        public Menu()
        {
            this.InitializeComponent();
            
            string novo = string.Format("select * from Produto where IdTipo='{0}'", 7);
            PratoPrincipal.ItemsSource = DbUtil.getInstance().getConnection().Query<Produto>(novo);
            novo = string.Format("select * from Produto where IdTipo='{0}'", 10);
            Sopa.ItemsSource = DbUtil.getInstance().getConnection().Query<Produto>(novo);
            novo = string.Format("select * from Produto where IdTipo='{0}'", 9);
            Sobremesa.ItemsSource = DbUtil.getInstance().getConnection().Query<Produto>(novo);
            novo = string.Format("select * from Produto where IdTipo='{0}'", 8);
            Bebida.ItemsSource = DbUtil.getInstance().getConnection().Query<Produto>(novo);
            novo = string.Format("select * from Produto where IdTipo='{0}'", 11);
            Apretivo.ItemsSource = DbUtil.getInstance().getConnection().Query<Produto>(novo);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void listView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
