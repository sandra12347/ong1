using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ong1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    enum ActionState
    {
        New,
        Edit,
        Delete,
        Nothing
    }
    public partial class MainWindow : Window
    {
        //using AutoLotModel;
        ActionState action = ActionState.Nothing;
        ONGModel.ONGModelEntitatati ctx = new ONGModel.ONGModelEntitatati();
        CollectionViewSource sediuVSource;
        CollectionViewSource customerOrdersVSource;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //using System.Data.Entity;
            sediuVSource =
           ((System.Windows.Data.CollectionViewSource)(this.FindResource("sediuViewSource")));
            sediuVSource.Source = ctx.Sedius.Local;
            ctx.Sedius.Load();
            sediuOrdersVSource =
((System.Windows.Data.CollectionViewSource)(this.FindResource("sediuOrdersViewSource")));

            sediuOrdersVSource.Source = ctx.Orders.Local;
            ctx.Eveniments.Load();
            ctx.Sponsors.Load();
            cmbSedius.ItemsSource = ctx.Sedius.Local;
            cmbSedius.DisplayMemberPath = "Nume";
            cmbSedius.SelectedValuePath = "IdSediu";
            cmbSponsor.ItemsSource = ctx.Inventories.Local;
            cmbSponsor.DisplayMemberPath = "Nume";
            cmbSponsor.SelectedValuePath = "IdSponsor";
        }
        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.New;
        }
        private void btnEditO_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.Edit;
        }
        private void btnDeleteO_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.Delete;
        }

        private void SaveSedius()
        {
            Sedius sediu = null;
            if (action == ActionState.New)
            {
                try
                {
                    //instantiem Sediu entity
                    sediu = new Sedius()
                    {
                        IdSediu = idSediuTextBox.Text.Trim(),
                        Adresa = adresaTextBox.Text.Trim()
                    };
                    //adaugam entitatea nou creata in context
                    ctx.Sedius.Add(sediu);
                    sediuVSource.View.Refresh();
                    //salvam modificarile
                    ctx.SaveChanges();
                }
                //using System.Data;
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
           if (action == ActionState.Edit)
            {
                try
                {
                    sediu = (sediu)sediuDataGrid.SelectedItem;
                    sediu.IdSediu = idSediuTextBox.Text.Trim();
                    sediu.Adresa = adresaTextBox.Text.Trim();
                    //salvam modificarile
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (action == ActionState.Delete)
            {
                try
                {
                    sediu = (Sedius)sediuDataGrid.SelectedItem;
                    ctx.Sedius.Remove(sediu);
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                sediuVSource.View.Refresh();
            }

        }


        private void SaveSponsors()
        {
            Sponsors sponsor = null;
            if (action == ActionState.New)
            {
                try
                {
                    //instantiem Sponsor entity
                    sponsor = new Sponsors()
                    {
                        IdSponsor = idSponsorTextBox.Text.Trim(),
                        Nume = numeTextBox.Text.Trim(),
                        Adresa = adresaTextBox.Text.Trim(),
                        Suma = sumaTextBox.Text.Trim()
                    };
                    //adaugam entitatea nou creata in context
                    ctx.Sponsors.Add(sponsor);
                    sponsorVSource.View.Refresh();
                    //salvam modificarile
                    ctx.SaveChanges();
                }
                //using System.Data;
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
           if (action == ActionState.Edit)
            {
                try
                {
                    sponsor = (Sponsors)sponsorDataGrid.SelectedItem;
                    sponsor.IdSponsor = idSponsorTextBox.Text.Trim();
                    sponsor.Nume =numeTextBox.Text.Trim();
                    sponsor.Adresa = adresaTextBox.Text.Trim();
                    sponsor.Suma = sumaTextBox.Text.Trim();
                    //salvam modificarile
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (action == ActionState.Delete)
            {
                try
                {
                    sponsor = (Sponsor)sponsorDataGrid.SelectedItem;
                    ctx.Sponsors.Remove(sponsor);
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                sponsorVSource.View.Refresh();
            }

        }

        private void tbCtrlong1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void evenimentDataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SaveEveniments()
        {
            Eveniments eveniments = null;
            if (action == ActionState.New)
            {
                try
                {
                    Sediu sediu = (Sediu)cmbSedius.SelectedItem;
                    Sponsor sponsor = (Sponsor)cmbSponsor.SelectedItem;
                   
                    sediu = new Sediu()
                    {

                         = sediu.IdSediu,
                        IdSponsor = sponsor.IdSponsor
                    };
                    ctx.Orders.Add(order);
                    //salvam modificarile
                    ctx.SaveChanges();
                    BindDataGrid();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
if (action == ActionState.Edit)
            {
                dynamic selectedEveniment = evenimentsDataGrid.SelectedItem;
                try
                {
                    int curr_id = selectedEveniment.IdEveniment;
                    var editedEveniment = ctx.Eveniments.FirstOrDefault(s => s.IdEveniment == curr_id);
                    if (editedEveniment != null)
                    {
                        editedEveniment.IdSediu = Int32.Parse(cmbSediu.SelectedValue.ToString());
                        editedEveniment.IdSponsor = Convert.ToInt32(cmbSponsor.SelectedValue.ToString());
                        //salvam modificarile
                        ctx.SaveChanges();
                    }
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                BindDataGrid();
                // pozitionarea pe item-ul curent
                sediuEvenimentVSource.View.MoveCurrentTo(selectedEveniment);
            }
            else if (action == ActionState.Delete)
            {
                try
                {
                    dynamic selectedEveniment = evenimentsDataGrid.SelectedItem;
                    int curr_id = selectedEveniment.EvenimentId;
                    var deletedEveniment = ctx.Eveniments.FirstOrDefault(s => s.EvenimentId == curr_id);
                    if (deletedEveniment != null)
                    {
                        ctx.Eveniments.Remove(deletedOrder);
                        ctx.SaveChanges();
                        MessageBox.Show("Eveniment Deleted Successfully", "Message");
                        BindDataGrid();
                    }
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

    }

}


