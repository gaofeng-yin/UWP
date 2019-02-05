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
    public sealed partial class RelatorioP : Page
    {
        public RelatorioP()
        {
            this.InitializeComponent();
            List<StatsProduto> produtos = DbUtil.getInstance().getConnection().Query<StatsProduto>("select ProdutosID, p.Nome, count(ProdutosID) as quantidade from EncomendaDetalhe ed left join Produto p on p.ID = ed.ProdutosID group by ProdutosID order by quantidade");
            foreach (StatsProduto statProduto in produtos)
            {
                this.statsProdutos.Items.Add(statProduto);
            }
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBlock_SelectionChanged_1(object sender, RoutedEventArgs e)
        {

        }
    }

    public class StatsProduto
    {
        public int ProdutosID { get; set; }
        public String Nome { get; set; }
        public int quantidade { get; set; }

        public override string ToString()
        {
            return this.ProdutosID + " - " + this.Nome + ": " + this.quantidade + " produtos encomendados";
        }
    }
}
